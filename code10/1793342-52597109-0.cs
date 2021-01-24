    int sum = 0;
            while (true)
            {
                string inputData = Console.ReadLine();
                if (inputData.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                int input = Convert.ToInt32(inputData);
                sum += input;
            }
            Console.WriteLine("Total sum is : " + sum);
            Console.ReadLine();
