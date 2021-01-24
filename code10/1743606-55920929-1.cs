    public static byte[] ToBigEndianBytes(this int i) {
        byte[] bytes = BitConverter.GetBytes(Convert.ToUInt64(i));
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        return bytes;
    }
