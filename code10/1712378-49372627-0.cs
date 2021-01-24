    public static class GuidTools
    {
        public static Guid GuidFromLongs(long a, long b)
        {
            byte[] guidData = new byte[16];
            Array.Copy(BitConverter.GetBytes(a), guidData, 8);
            Array.Copy(BitConverter.GetBytes(b), 0, guidData, 8, 8);
            return new Guid(guidData);
        }
        public static (long, long) ToLongs(this Guid guid)
        {
            var bytes = guid.ToByteArray();
            var long1 = BitConverter.ToInt64(bytes, 0);
            var long2 = BitConverter.ToInt64(bytes, 8);
            return (long1, long2);
        }
    }
