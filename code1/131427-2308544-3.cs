        static int getNewValue(string s)
        {
            int sum = 0;
            foreach (char c in s)
            {
                sum += Convert.ToInt32(c.ToString());
            }
            int newDigit = (10 - (sum % 10) + 1) % 10;
            return newDigit;
        }
