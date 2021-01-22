        static string getNewValue(string s)
        {
            int sum = 0;
            foreach (char c in s)
            {
                sum += Convert.ToInt32(c.ToString());
            }
            int newDigit = (10 - (sum % 10) + 1) % 10;
            if (newDigit != 0)
            {
                s += newDigit.ToString();
            }
            return s;
        }
