    public static bool IsNumeric(string strNumber)
        {
            if (string.IsNullOrEmpty(strNumber))
            {
                return false;
            }
            else
            {
                int numberOfChar = strNumber.Count();
                if (numberOfChar > 0)
                {
                    bool r = strNumber.All(char.IsDigit);
                    return r;
                }
                else
                {
                    return false;
                }
            }
        }
