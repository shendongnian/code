    private byte[] GetBytesFromHex(string hex) {
        byte[] bytes = new byte[result.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] = Convert.ToByte(result.Substring(i * 2, 2), 16);
    }
