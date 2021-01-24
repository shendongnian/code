    public static double RoundOff(this long rawNumber, double roundToNearest)
    {
        return RoundOff((double) rawNumber, roundToNearest);
    }
    public static double RoundOff(this double rawNumber, double roundToNearest)
    {
        T rawMultiples     = rawNumber / roundToNearest;
        T roundedMultiples = Math.Round(rawMultiples);
        T roundedNumber    = roundedMultiples * roundToNearest;
        return roundedNumber;
    }
