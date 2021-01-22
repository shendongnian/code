        // I use this function
        public static string ToBinary(long number)
        {
            string digit = Convert.ToString(number % 2);
            if (number >= 2)
            {
                long remaining = number / 2;
                string remainingString = ToBinary(remaining);
                return remainingString + digit;
            }
            return digit;
         }
