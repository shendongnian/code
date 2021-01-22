    public static class IntToBytesExtension
    {
        private const int PRECISION = 2;
        private static IList<string> Units;
        static IntToBytesExtension()
        {
            Units = new List<string>(){
                "B", "KB", "MB", "GB", "TB"
            };
        }
        /// <summary>
        /// Formats the value as a filesize in bytes (KB, MB, etc.)
        /// </summary>
        /// <param name="bytes">This value.</param>
        /// <returns>Filesize and quantifier formatted as a string.</returns>
        public static string ToBytes(this int bytes)
        {
            double pow = Math.Floor((bytes>0 ? Math.Log(bytes) : 0) / Math.Log(1024));
            pow = Math.Min(pow, Units.Count-1);
            double value = (double)bytes / Math.Pow(1024, pow);
            return value.ToString(pow==0 ? "F0" : "F" + PRECISION.ToString()) + " " + Units[(int)pow];
        }
    }
