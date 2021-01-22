            static void Main(string[] args) 
            {
            Console.WriteLine("Enter number for converting to binary numerical system!");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[16];
            //for positive integers
            if (num > 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (num > 0)
                    {
                        if ((num % 2) == 0)
                        {
                            num = num / 2;
                            arr[16 - (i + 1)] = 0;
                        }
                        else if ((num % 2) != 0)
                        {
                            num = num / 2;
                            arr[16 - (i + 1)] = 1;
                        }
                    }
                }
                for (int y = 0; y < 16; y++)
                {
                    Console.Write(arr[y]);
                }
                Console.ReadLine();
            }
            //for negative integers
            else if (num < 0)
            {
                num = (num + 1) * -1;
                for (int i = 0; i < 16; i++)
                {
                    if (num > 0)
                    {
                        if ((num % 2) == 0)
                        {
                            num = num / 2;
                            arr[16 - (i + 1)] = 0;
                        }
                        else if ((num % 2) != 0)
                        {
                            num = num / 2;
                            arr[16 - (i + 1)] = 1;
                        }
                    }
                }
                for (int y = 0; y < 16; y++)
                {
                    if (arr[y] != 0)
                    {
                        arr[y] = 0;
                    }
                    else
                    {
                        arr[y] = 1;
                    }
                    Console.Write(arr[y]);
                }
                Console.ReadLine();
            }           
        }
