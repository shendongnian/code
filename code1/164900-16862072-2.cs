    public string DisplayNDecimal(double dbValue, int nDecimal)
    {
        string decimalPoints = "0";
        if (nDecimal > 0)
        {
            decimalPoints += ".";
            for (int i = 0; i < nDecimal; i++)
                decimalPoints += "0";
        }
        return dbValue.ToString(decimalPoints);
    }
