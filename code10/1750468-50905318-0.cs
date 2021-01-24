    public const string BaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
    public static string Random(int length, string alphabet = BaseAlphabet)
    {
        StringBuilder result = new StringBuilder(length);
        uint maxValue = (uint)((((ulong)uint.MaxValue) + 1) / (uint)alphabet.Length * (uint)alphabet.Length);
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            for (int i = 0; i < length; i++)
            {
                uint num;
                do
                {
                    byte[] buffer = new byte[sizeof(uint)];
                    rng.GetBytes(buffer);
                    num = BitConverter.ToUInt32(buffer, 0);
                }
                while (num >= maxValue);
                result.Append(alphabet[(int)(num % (uint)alphabet.Length)]);
            }
        }
        return result.ToString();
    }
