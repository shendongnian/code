        public static double RoundToSigFigs(this double d, int sigFigures)
        {
            double scale = Math.Pow(10, Math.Ceiling(Math.Log10(Math.Abs(d))));
            return scale * Math.Round(d / scale, sigFigures);
        }
        public static string ToString(this double d, int sigFigures)
        {
            double dRounded = d.RoundToSigFigs(sigFigures);
            int roundingPosition = sigFigures - 1 - (int)(Math.Floor(Math.Log10(Math.Abs(d))));
            return roundingPosition >= 0 ? string.Format("{0:F" + (roundingPosition) + "}", dRounded) : dRounded.ToString();
        }
