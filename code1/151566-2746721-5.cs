    public static void Main()
    {
        float f = -23984.123f;
        ushort s1;
        ushort s2;
        SplitToWords(f, out s1, out s2);
        Console.WriteLine("{0} : {1}/{2}", f, s1, s2);
        byte[] fBytes = BitConverter.GetBytes(f);
        s2 = BitConverter.ToUInt16(fBytes, 0);
        s1 = BitConverter.ToUInt16(fBytes, 2);
        Console.WriteLine("{0} : {1}/{2}", f, s1, s2);
        Console.ReadKey();
    }
