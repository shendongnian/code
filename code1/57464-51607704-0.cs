    public static bool IsNumeric(this string input)
    {
        int n;
        if (!string.IsNullOrEmpty(input))
        {
            foreach (var i in input)
            {
                if (!int.TryParse(i.ToString(), out n))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
