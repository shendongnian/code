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
                return (int)(number * 10);
            }
            return (number * 10).DigitAtPosition(position - 1);
        }
    }
