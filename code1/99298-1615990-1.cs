        public static void ConvertToArrayOfDigits(int value, int[] digits) { ... }
        public static int[] ConvertToArrayOfDigits(int value)
        {
            int size = DetermineDigitCount(value);
            int[] digits = new int[size];
            ConvertToArrayOfDigits(value, digits);
            return digits;
        }
