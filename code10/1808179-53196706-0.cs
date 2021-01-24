        public static double IsValad(double x)
        {
                if (x > 0)
                {
                    return x;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a positive value.");
                    x = double.Parse(Console.ReadLine());
                    return x;
                }
        }
