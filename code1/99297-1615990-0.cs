        private static readonly int[] _buffer = new int[10];
        public static int[] ConvertToArrayOfDigits(int value)
        {
            for (int index = 9; index >= 0; index--)
            {
                _buffer[index] = value % 10;
                value = value / 10;
            }
            return _buffer;
        }
