    int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string[] topIntegers = new string[numbers.Length];
            int maximumValue = int.MinValue;
            int j = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] > maximumValue)
                {
                    maximumValue = numbers[i];
                    topIntegers[j] = maximumValue.ToString();
                }
                j++;
            }
            for (int i = topIntegers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{topIntegers[i]} ");
            }
