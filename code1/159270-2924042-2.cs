    using System;
    
    public static class DecimalExtensions
    {
        public static int DigitAtPosition(this decimal number, int position)
        {
            if (position <= 0)
            {
                throw new ArgumentException("Position must be positive.");
            }
            if (number < 0)
            {
                number = Math.Abs(number);
            }
            if (number > ulong.MaxValue)
            {
                number %= ulong.MaxValue;
            }
            number -= (ulong)number;
            if (number == 0)
            {
                return 0;
            }
            if (position == 1)
            {
                return (int)(10 * number);
            }
            return DigitAtPosition(number * 10, position - 1);
        }
    }
