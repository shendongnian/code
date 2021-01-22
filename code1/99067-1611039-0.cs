    private static byte[] _temp = new byte[0];
    public static void Swap(byte[] data)
    {
        if (data.Length > _temp.Length)
        {
            _temp = new byte[data.Length];
        }
        Buffer.BlockCopy(data, 1, _temp, 0, data.Length - 1);
        for (int i = 0; i < data.Length; i += 2)
        {
            _temp[i + 1] = data[i];
        }
        Buffer.BlockCopy(_temp, 0, data, 0, data.Length);
    }
