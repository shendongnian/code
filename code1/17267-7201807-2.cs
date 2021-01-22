        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0);
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            return (long) (dateTime - Epoch).TotalSeconds;
        }
        public static long ToUnixUltraTimestamp(this DateTime dateTime)
        {
            return (long) (dateTime - Epoch).TotalMilliseconds;
        }
