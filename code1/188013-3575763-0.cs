        double d = 12.09;
        Console.WriteLine("Double value: " + d.ToString());
        byte[] bytes = BitConverter.GetBytes(d);
        Console.WriteLine("Byte array value:");
        Console.WriteLine(BitConverter.ToString(bytes));
