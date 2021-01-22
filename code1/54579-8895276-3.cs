        public String columnName(long columnNumber)
        {
            StringBuilder retVal = new StringBuilder();
            int x = 0;
  
            for (int n = (int)(Math.Log(25*(columnNumber + 1))/Math.Log(26)) - 1; n >= 0; n--)
            {
                x = (int)((Math.Pow(26,(n + 1)) - 1) / 25 - 1);
                if (columnNumber > x)
                    retVal.Append(System.Convert.ToChar((int)(((columnNumber - x - 1) / Math.Pow(26, n)) % 26 + 65)));
            }
            return retVal.ToString();
        }
