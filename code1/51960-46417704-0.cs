        static string DoubleToEngineering(double value, string displayPrecision)
        {
            string Retval;
            if (double.IsNaN(value)
                || double.IsInfinity(value)
                || double.IsNegativeInfinity(value)
                || double.IsPositiveInfinity(value)
                || value == 0.0
                )
            {
                Retval  = String.Format("{0:" + "F" + displayPrecision + "}", value);
                return Retval;
            }
            bool isNeg = value < 0;
            if (isNeg) value = -value;
            int exp = (int)(Math.Floor(Math.Log10(value) / 3.0) * 3.0);
            int powerToRaise = -exp;
            double newValue = value;
            // Problem: epsilon is something-324
            // The biggest possible number is somethinge306
            // You simply can't do a Math.Power (10, 324), it becomes infiniity.
            if (powerToRaise > 300)
            {
                powerToRaise -= 300;
                newValue = newValue * Math.Pow(10.0, 300);
            }
            newValue = newValue * Math.Pow(10.0, powerToRaise);
            // I don't know when this below is triggered.
            if (newValue >= 1000.0)
            {
                newValue = newValue / 1000.0;
                exp = exp + 3;
            }
            var fmt = "{0:F" + displayPrecision + "}";
            Retval = String.Format (fmt, newValue);
            if (exp != 0) Retval += String.Format("e{0}", exp);
            if (isNeg) Retval = "-" + Retval;
            return Retval;
        }
