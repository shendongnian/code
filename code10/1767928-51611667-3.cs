    float num = 1.2f;
    if (!BitConverter.IsLittleEndian)
    {
        byte[] bytes = BitConverter.GetBytes(num);
        Array.Reverse(bytes, 0, bytes.Length);
        num = BitConverter.ToSingle(bytes, 0);
    }
    Console.WriteLine(num);
