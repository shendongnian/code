    void q50415070()
    {
        var output = new byte[16] { 0xE2, 0x72, 0xE2, 0x8B, 0x89, 0x61, 0xFB, 0x15, 0x5E, 0x3F, 0xC6, 0x57, 0x83, 0x1F, 0x06, 0x90 };
        Debug.WriteLine(BitConverter.ToString(output));
        // E2-72-E2-8B-89-61-FB-15-5E-3F-C6-57-83-1F-06-90
        var random = new Random();
        var part1 = new byte[16];
        random.NextBytes(part1);
        Debug.WriteLine(BitConverter.ToString(part1));
        // 59-37-D0-A6-71-CC-6C-17-96-02-70-CE-A7-57-06-25
        var part2 = part1.Zip(output, (x, y) => (byte)(x ^ y)).ToArray();
        Debug.WriteLine(BitConverter.ToString(part2));
        // BB-45-32-2D-F8-AD-97-02-C8-3D-B6-99-24-48-00-B5
    }
