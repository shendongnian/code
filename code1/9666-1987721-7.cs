            public static double RoundToSigFigs(this double value, int sigFigures)
        {
            // this method will return a rounded double value at a number of signifigant figures.
            // the sigFigures parameter must be between 0 and 15, exclusive.
            int roundingPosition;   // The rounding position of the value at a number of sig figures.
            double scale;           // Optionally used scaling value, for rounding whole numbers or decimals past 15 places
            // handle exceptional cases
            if (value == 0.0d) { return value; }
            if (double.IsNaN(value)) { return double.NaN; }
            if (double.IsPositiveInfinity(value)) { return double.PositiveInfinity; }
            if (double.IsNegativeInfinity(value)) { return double.NegativeInfinity; }
            if (sigFigures < 1 || sigFigures > 14) { throw new ArgumentOutOfRangeException("The sigFigures argument must be between 0 and 15 exclusive."); }
            // The resulting rounding position will be negative for rounding at whole numbers, and positive for decimal places.
            roundingPosition = sigFigures - 1 - (int)(Math.Floor(Math.Log10(Math.Abs(value))));
            // try to use a rounding position directly, if no scale is needed.
            // this is because the scale mutliplication after the rounding can introduce error, although 
            // this only happens when you're dealing with really tiny numbers, i.e 9.9e-14.
            if (roundingPosition > 0 && roundingPosition < 15)
            {
                return Math.Round(value, roundingPosition, MidpointRounding.AwayFromZero);
            }
            else
            {
                scale = Math.Pow(10, Math.Ceiling(Math.Log10(Math.Abs(value))));
                return Math.Round(value / scale, sigFigures, MidpointRounding.AwayFromZero) * scale;
            }
        }
        public static string ToString(this double value, int sigFigures)
        {
            // this method will round and append zeros if needed.
            // handle exceptional cases
            if (value == 0.0d) { return "0.0"; }
            if (double.IsNaN(value)) { return "Not a Number"; }
            if (double.IsPositiveInfinity(value)) { return "Positive Infinity"; }
            if (double.IsNegativeInfinity(value)) { return "Negative Infinity"; }
            return string.Format("{0:G" + sigFigures.ToString() + "}", value);
        }
