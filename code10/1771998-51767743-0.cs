        public static int MaxValid(string input)
        {
            var max = 0;
            var current = 0;
            bool upper = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input, i))
                {
                    if (upper && current > max)
                        max = current;
                    current = 0;
                    upper = false;
                }
                else
                {
                    current++;
                    if (char.IsUpper(input, i))
                        upper = true;
                }
            }
            return max;
        }
