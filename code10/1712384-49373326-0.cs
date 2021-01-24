        public static void GuidToInt16(Guid guidToConvert, out long guidAsLong1, out long guidAsLong2)
        {
            byte[] guidByteArray = guidToConvert.ToByteArray();
            var segment1 = new ArraySegment<byte>(guidByteArray, 0, 8);
            var segment2 = new ArraySegment<byte>(guidByteArray, 8, 8);
            guidAsLong1 = BitConverter.ToInt64(segment1.ToArray(), 0);
            guidAsLong2 = BitConverter.ToInt64(segment2.ToArray(), 0);
        }
        public static Guid Int16ToGuid(long guidAsLong1, long guidAsLong2)
        {
            var segment1 = BitConverter.GetBytes(guidAsLong1);
            var segment2 = BitConverter.GetBytes(guidAsLong2);
            return new Guid(segment1.Concat(segment2).ToArray());
        }
