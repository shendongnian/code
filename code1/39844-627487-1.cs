    private static long IsPrime(long input)
            {
                if ((input % 2) == 0)
                {
                    return 2;
                }
                else if ((input == 1))
                {
                    return 1;
                }
                else
                {
                    long threshold = (Convert.ToInt64(Math.Sqrt(input)));
                    long tryDivide = 3;
                    while (tryDivide <= threshold)
                    {
                        if ((input % tryDivide) == 0)
                        {
                            Console.WriteLine("Found a factor: " + tryDivide);
                            return tryDivide;
                        }
                        tryDivide += 2;
                    }
                    Console.WriteLine("Found a factor: " + input);
                    return -1;
                }
            }
