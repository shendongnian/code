    public static class StringStep
    {
        public static string Next(string str)
        {
            string result = String.Empty;
            int index = str.Length - 1;
            bool carry;
            do
            {
                result = Increment(str[index--], out carry) + result;              
            }
            while (carry && index >= 0);
            if (index >= 0) result = str.Substring(0, index+1) + result;
            if (carry) result = "a" + result;
            return result;
        }
    
        private static char Increment(char value, out bool carry)
        {
            carry = false;
            if (value >= 'a' && value < 'z' || value >= 'A' && value < 'Z')
            {
                return (char)((int)value + 1);
            }
            if (value == 'z') return 'A';
            if (value == 'Z')
            {
                carry = true;
                return 'a';
            }
            throw new Exception(String.Format("Invalid character value: {0}", value));
        }
    }
