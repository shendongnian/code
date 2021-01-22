    static double GetPrecision(string s)
    { 
        string[] splitNumber = s.Split('.');
        if (splitNumber.Length > 1)
        {
            return 1 / Math.Pow(10, splitNumber[1].Length);
        }
        else
        {
            return 1;
        }
    }
