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
            return number.digitAtPosition(position);
        }
        static int digitAtPosition(this decimal sanitizedNumber, int validPosition)
        {
            sanitizedNumber -= Math.Floor(sanitizedNumber);
            if (sanitizedNumber == 0)
            {
                return 0;
            }
            if (validPosition == 1)
            {
                return (int)(sanitizedNumber * 10);
            }
            return (sanitizedNumber * 10).digitAtPosition(validPosition - 1);
        }
