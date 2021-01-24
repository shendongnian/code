        public static void GetFlags(int value)
        {
            for (int i = 0; i < 20; i++)
            {
                if (((1 << i) & value) > 0)
                    Console.WriteLine($"Status {i + 1} is present");
            }
        }
