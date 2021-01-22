    public static class LongExtensions
    {
        private static readonly long[] numberOfBytesInUnit;
        private static readonly Func<long, string>[] bytesToUnitConverters;
        static LongExtensions()
        {
            numberOfBytesInUnit = new long[6]    
            {
                1L << 10,    // Bytes in a Kibibyte
                1L << 20,    // Bytes in a Mebibyte
                1L << 30,    // Bytes in a Gibibyte
                1L << 40,    // Bytes in a Tebibyte
                1L << 50,    // Bytes in a Pebibyte
                1L << 60     // Bytes in a Exbibyte
            };
            // Shift the long (integer) down to 1024 times its number of units, convert to a double (real number), 
            // then divide to get the final number of units (units will be in the range 1 to 1023.999)
            Func<long, int, string> FormatAsProportionOfUnit = (bytes, shift) => (((double)(bytes >> shift)) / 1024).ToString("0.###");
            bytesToUnitConverters = new Func<long,string>[7]
            {
                bytes => bytes.ToString() + " B",
                bytes => FormatAsProportionOfUnit(bytes, 0) + " KiB",
                bytes => FormatAsProportionOfUnit(bytes, 10) + " MiB",
                bytes => FormatAsProportionOfUnit(bytes, 20) + " GiB",
                bytes => FormatAsProportionOfUnit(bytes, 30) + " TiB",
                bytes => FormatAsProportionOfUnit(bytes, 40) + " PiB",
                bytes => FormatAsProportionOfUnit(bytes, 50) + " EiB",
            };
        }
        public static string ToReadableByteSizeString(this long bytes)
        {
            if (bytes < 0)
                return "-" + Math.Abs(bytes).ToReadableByteSizeString();
            int counter = 0;
            while (counter < numberOfBytesInUnit.Length)
            {
                if (bytes < numberOfBytesInUnit[counter])
                    return bytesToUnitConverters[counter](bytes);
                counter++;
            }
            return bytesToUnitConverters[counter](bytes);
        }
    }
