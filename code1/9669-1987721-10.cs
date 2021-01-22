    private static double RoundSignificantDigits(double value, int sigFigures, out int roundingPosition)
    {
        // this method will return a rounded double value at a number of signifigant figures.
        // the sigFigures parameter must be between 0 and 15, exclusive.
        roundingPosition = 0;
        // ToDo: Might want to compare with epsilon here
        if (value == 0.0d)
        {
            return value;
        }
        if (double.IsNaN(value))
        {
            return double.NaN;
        }
        if (double.IsPositiveInfinity(value))
        {
            return double.PositiveInfinity;
        }
        if (double.IsNegativeInfinity(value))
        {
            return double.NegativeInfinity;
        }
        if (sigFigures < 1 || sigFigures > 14)
        {
            throw new ArgumentOutOfRangeException("sigFigures", value, "The sigFigures argument must be between 0 and 15 exclusive.");
        }
        // The resulting rounding position will be negative for rounding at whole numbers, and positive for decimal places.
        roundingPosition = sigFigures - 1 - (int)(Math.Floor(Math.Log10(Math.Abs(value))));
        // try to use a rounding position directly, if no scale is needed.
        // this is because the scale mutliplication after the rounding can introduce error, although 
        // this only happens when you're dealing with really tiny numbers, i.e 9.9e-14.
        if (roundingPosition > 0 && roundingPosition < 15)
        {
            return Math.Round(value, roundingPosition, MidpointRounding.AwayFromZero);
        }
        // Shouldn't get here unless we need to scale it.
        // Set the scaling value, for rounding whole numbers or decimals past 15 places
        double scale = Math.Pow(10, Math.Ceiling(Math.Log10(Math.Abs(value))));
        return Math.Round(value / scale, sigFigures, MidpointRounding.AwayFromZero) * scale;
    }
    public static double RoundSignificantDigits(this double value, int sigFigures)
    {
        int unneededRoundingPosition;
        return RoundSignificantDigits(value, sigFigures, out unneededRoundingPosition);
    }
    public static string ToString(this double value, int sigFigures)
    {
        // this method will round and then append zeros if needed.
        // i.e. if you round .002 to two significant figures, the resulting number should be .0020.
        var currentInfo = CultureInfo.CurrentCulture.NumberFormat;
        // ToDo: Might want to compare with epsilon here
        if (value == 0.0d)
        {
            return 0.0d.ToString(currentInfo);
        }
        if (double.IsNaN(value))
        {
            return currentInfo.NaNSymbol;
        }
        if (double.IsPositiveInfinity(value))
        {
            return currentInfo.PositiveInfinitySymbol;
        }
        if (double.IsNegativeInfinity(value))
        {
            return currentInfo.NegativeInfinitySymbol;
        }
        int roundingPosition = 0;
        double roundedValue = RoundSignificantDigits(value, sigFigures, out roundingPosition);
        // If the above rounding evaluates to zero, just return zero without padding.
        // Todo:  Might want to compare with epsilon here
        // Todo:  Consider whether it's more correct to return zero at a certain precision here (ie. .000 or zero at 3 sig figs).  For my purposes zero is zero.
        if (roundedValue == 0.0d)
        {
            return 0.0d.ToString(currentInfo);
        }
        // Check if the rounding position is positive and is not past 100 decimal places.
        // If the rounding position is greater than 100, string.format won't represent the number correctly.
        // ToDo:  What happens when the rounding position is greater than 100?
        if (roundingPosition > 0 && roundingPosition < 100)
        {
            return string.Format(currentInfo, "{0:F" + roundingPosition + "}", roundedValue);
        }
        // Shouldn't get here unless it's a whole number
        // String.format is only needed when dealing with decimals (whole numbers won't need to be padded with zeros to the right.)
        return roundedValue.ToString(currentInfo);
    }
