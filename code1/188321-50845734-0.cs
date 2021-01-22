        public string[] ExtractNumbersFromString(string input)
        {
            input = input.Replace(",", string.Empty);
            var numbers =  Regex.Split(input, @"[^0-9\.]+").Where(c => !String.IsNullOrEmpty(c) && c != ".").ToArray();
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = decimal.Parse(numbers[i]).ToString();
            return numbers;
        }
