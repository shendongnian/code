    void q50415070()
    {
        var random = new Random();
        var output = new byte[16];
        random.NextBytes(output);
        Debug.WriteLine(BitConverter.ToString(output));
        // 91-77-E9-2F-EC-F7-8E-CC-03-AF-37-FD-4F-6F-D2-4D
        var part1 = new byte[16];
        random.NextBytes(part1);
        Debug.WriteLine(BitConverter.ToString(part1));
        // 7A-9B-2B-8B-D7-CE-AA-7E-7E-C3-FE-FF-44-2A-21-3C
        var part2 = part1.Zip(output, (x, y) => (byte)(x ^ y)).ToArray();
        Debug.WriteLine(BitConverter.ToString(part2));
        // EB-EC-C2-A4-3B-39-24-B2-7D-6C-C9-02-0B-45-F3-71
    }
