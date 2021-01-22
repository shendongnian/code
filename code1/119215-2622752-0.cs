        /// <summary>
        /// Reverse a int using its sting representation.
        /// </summary>
        private int ReverseNumber(int value)
        {
            string textValue = value.ToString().TrimStart('-');
            char[] valueChars = textValue.ToCharArray();
            Array.Reverse(valueChars);
            string reversedValue = new string(valueChars);
            int reversedInt = int.Parse(reversedValue);
            if (value < 0)
               reversedInt *= -1;
            return reversedInt;
        }
