    public static string GenerateRandomString(int length)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var result = new System.Text.StringBuilder(length);
        var bytes = CryptographicBuffer.GenerateRandom((uint)length * 4).ToArray();
        for (int i = 0; i < bytes.Length; i += 4)
        {
            result.Append(BitConverter.ToUInt32(bytes, i) % chars.Length);
        }
        return result.ToString();
    }
