    public static bool TryParseToPromille(string input, IFormatProvider formatProvider, out int promille)
    {
        bool result = false;
        promille = 0;
        if(Decimal.TryParse(input, NumberStyles.Number, formatProvider, out decimal value))
        {
            result = true;
            value = value * 1000;
            promille = (int)Math.Truncate(value); // or "Round" or "Ceiling" or "Floor" depending on your use case
        }
        return result;
    }
    public static bool TryParseToPromille(string input, out int promille)
    {
        return TryParseToPromille(input, CultureInfo.CurrentCulture, out promille);
    }
