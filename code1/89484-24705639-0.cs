        public static int GetHighint(long intValue)
        {
            return Convert.ToInt32(intValue >> 32);
        }
        public static int GetLowint(long intValue)
        {
            long tmp = intValue << 32;
            return Convert.ToInt32(tmp >> 32);
        }
