        public int ReadStartingNumber(string text)
        {
            if (string.IsNullOrEmpty(text) || !char.IsDigit(text[0]))
                throw new FormatException("Text does not start with any digits");
            int result = 0;
            foreach (var digit in text.TakeWhile(c => char.IsDigit(c)))
            {
                result = 10*result + (digit - '0');
            }
            return result;
        }
