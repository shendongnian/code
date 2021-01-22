    public static class PrecisionHelper
    {
        public static decimal TwoDecimalPlaces(this decimal value)
        {
            // These first lines eliminate all digits past two places.
            var timesHundred = (int) (value * 100);
            var removeZeroes = timesHundred / 100m;
            
            // In this implementation, I don't want to alter the underlying
            // value.  As such, if it needs greater precision to stay unaltered,
            // I return it.
            if (removeZeroes != value)
                return value;
            // Addition and subtraction can reliably change precision.  
            // For two decimal values A and B, (A + B) will have at least as 
            // many digits past the decimal point as A or B.
            return removeZeroes + 0.01m - 0.01m;
        }
    }
