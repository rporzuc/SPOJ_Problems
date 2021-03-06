
using System;


namespace Problem_FANGEN
{
    class Program
    {
        static void Main()
        {
            int number;
            do
            {
                number = int.Parse(Console.ReadLine());
                WindMills w = new WindMills(number);
                w.showWindMill();

            } while (number != 0);
        }
    }

    class WindMills
    {
        int size;
        char way;

char[,] mainArray;
        
        public WindMills(int size)
        {
            this.size = Math.Abs(size);
            if (size < 0) {
                way = '-';
            }
            else
            {
                way = '+';
            }

 mainArray = createWindMill(this.size);

        }

        public char[,] createWindMill(int s)
        {


            char[,] ar = new char[2*s, 2*s];

			// insert dots into array
            for (int i = 0; i < 2*s; i++)
            {
                for (int j = 0; j < 2*s; j++)
                {
                    ar[i, j] = '.';
                }
            }

            //paste array 
            if (s > 1)
            {
                char[,] childArray = createWindMill(s - 1);

                for (int i = 1; i < 2*s -1 ; i++)
                {
                    for (int j = 1; j < 2*s -1 ; j++)
                    {
                        ar[i, j] = childArray[i - 1, j - 1];
                    }
                }
                
            }
            if (way == '-')
            {
                // right windmill
                for (int j = 0; j < s; j++)
                {
                    ar[0, j] = '*';
                }
                for (int j = 2 * s - 1; j >= s; j--)
                {
                    ar[(2 * s - 1), j] = '*';
                }
                for (int i = 0; i < s; i++)
                {
                    ar[i, (2 * s - 1)] = '*';
                }
                for (int i = 2 * s - 1; i >= s; i--)
                {
                    ar[i, 0] = '*';
                }
            }
            else
            {
                // left windmill
                for (int j = 0; j < s; j++)
                {
                    ar[(2 * s - 1), j] = '*';
                }
                for (int j = 2 * s - 1; j >= s; j--)
                {
                    ar[0, j] = '*';
                }
                for (int i = 0; i < s; i++)
                {
                    ar[i, 0] = '*';
                }
                for (int i = 2 * s - 1; i >= s; i--)
                {
                    ar[i, (2 * s - 1)] = '*';
                }
            }
            return ar;
        }

        public void showWindMill()
        {

           
            

            for (int i = 0; i< 2* size; i++)
            {
                for (int j = 0; j < 2* size; j++)
                {
                    Console.Write(mainArray[i, j]);

                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
    }
}
