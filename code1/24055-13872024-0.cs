    static ClassName()
    {
        powersOf10 = new decimal[28 + 1 + 28];
        powersOf10[28] = 1;
        decimal pup = 1, pdown = 1;
        for (int i = 1; i < 29; i++) {
            pup *= 10;
            powersOf10[i + 28] = pup;
            pdown /= 10;
            powersOf10[28 - i] = pdown;
        }
    }
    /// <summary>Powers of 10 indexed by power+28.  These are all the powers
    /// of 10 that can be represented using decimal.</summary>
    static decimal[] powersOf10;
    static double RoundToSignificantDigits(double v, int digits)
    {
        if (v == 0.0 || Double.IsNaN(v) || Double.IsInfinity(v)) {
            return v;
        } else {
            int decimal_exponent = (int)Math.Floor(Math.Log10(Math.Abs(v))) + 1;
            if (decimal_exponent < -28 + digits || decimal_exponent > 28 - digits) {
                // Decimals won't help outside their range of representation.
                // Insert flawed Double solutions here if you like.
                return v;
            } else {
                decimal d = (decimal)v;
                decimal scale = powersOf10[decimal_exponent + 28];
                return (double)(scale * Math.Round(d / scale, digits, MidpointRounding.AwayFromZero));
            }
        }
    }
