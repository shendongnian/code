    public static bool validateAmount(string amount)
    {
        int posDecSep = amount.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
        int decimalPlaces = amount.Length - posDecSep - 1;
        if (posDecSep < 0) { decimalPlaces = 0; }
        if (decimalPlaces > 2)
        {
            //handle error with args, or however your validation works
            return false;
        }
        decimal decAmount;
        if (decimal.TryParse(amount, out decAmount))
        {
            if (decAmount > 0)
            {
                //positive
            }
            else
            {
                //negative
            }
        }
        return true;
    }
