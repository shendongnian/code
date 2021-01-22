    public class ExtensionMethods
    {
        public static RoundOff (this int i)
        {
            return ((int)(i / 10)) * 10;
        }
    }
    int roundedNumber = 236.RoundOff(); // returns 240
    int roundedNumber2 = 11.RoundOff(); // returns 10
