    private static void Main(string[] args)
    {
        var largeStringOfOneMB = "Hello World";
        var largeStringOfOneMBAsByteArray = Encoding.UTF8.GetBytes(largeStringOfOneMB);
        var largeStringOfOneMBAsStream = new MemoryStream(largeStringOfOneMBAsByteArray);
        var newByteArray = new byte[256];
        for (int i = 0; i <= largeStringOfOneMBAsByteArray.Length / 256; i++)
        {
            largeStringOfOneMBAsStream.Read(newByteArray, i * 256, 256);
            var newStringWith256BytesOfTheOriginalString = Encoding.UTF8.GetString(newByteArray);
            // Do what ever you have to
        }
    }
