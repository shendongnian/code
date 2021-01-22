        public static bool IsDigit(string myString)
        {
            string pattern = @"^\d*$";
        
            if (Regex.IsMatch(myString, pattern))
                return true;
            else
                return false;
        }
