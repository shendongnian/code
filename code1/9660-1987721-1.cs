    public static double RoundSigFigures(double input, int sigFigures)
    {
        if (input == 0)
        {
            return 0.0d;
        }
    
        if (double.IsNaN(input) || double.IsNegativeInfinity(input) || double.IsPositiveInfinity(input))
        {
            throw new ArgumentException("Please don't ask me to round positive/negative infinity or NaN values.");
        }
    
        return
            Math.Round(
                input,
                (sigFigures - 1 - (int)(Math.Floor(Math.Log10(Math.Abs(input))))),
                MidpointRounding.AwayFromZero
            );
    }
