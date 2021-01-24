    public static string ToBinaryString(this BigInteger bigint) {
        var bytes = bigint.ToByteArray();
        // Create a StringBuilder having appropriate capacity.
        var base2 = new StringBuilder(bytes.Length * 8);
        // Convert remaining bytes adding leading zeros.
        var idx = bytes.Length - 1;
        for (; idx > 0 && bytes[idx] == 0; --idx)
            ;
        for (; idx >= 0; --idx)
            base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
        return base2.ToString();
    }
