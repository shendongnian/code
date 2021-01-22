    public static class ExtensionMethods
    {
        public static int RoundOff (this int i)
        {
            return ((int)Math.Round(i / 10.0)) * 10;
        }
    }
    int roundedNumber = 236.RoundOff(); // returns 240
    int roundedNumber2 = 11.RoundOff(); // returns 10
