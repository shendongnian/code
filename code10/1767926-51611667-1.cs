    double num = 1.2;
    if (!BitConverter.IsLittleEndian)
    {
        byte[] bytes = BitConverter.GetBytes(num);
        Array.Reverse(bytes, 0, bytes.Length);
        num = BitConverter.ToDouble(bytes, 0);
    }
    Console.WriteLine(num);
