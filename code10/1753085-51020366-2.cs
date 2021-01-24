    static void TestSHA512Modify()
    {
        var testFile = Path.GetTempFileName();
        CreateRandomFile(testFile, 1024);
        var sha12 = GetFileSHA512(testFile);
        Console.WriteLine("TestSHA12Modify: Original file SHA512: " + ToHexString(sha12));
        // Modify file bytes. Here we set byte offset [100] [101] [102]
        WriteBytes(testFile, 100, new byte[] { 1, 2, 3 });
        var modifiedSha12 = GetFileSHA512(testFile);
        Console.WriteLine("TestSHA12Modify: Updated file SHA512:  " + ToHexString(modifiedSha12));
        Console.WriteLine("TestSHA12Modify: SHA12 Hashes are: " + (sha12.SequenceEqual(modifiedSha12) ? "EQUAL" : "NOT EQUAL"));
    }
    static void TestSHA512Append()
    {
        var testFile = Path.GetTempFileName();
        CreateRandomFile(testFile, 1024);
        var sha12 = GetFileSHA512(testFile);
        Console.WriteLine("TestSHA12Append: Original file SHA512: " + ToHexString(sha12));
        // Append bytes to the end of a file
        AppendBytes(testFile, new byte[] { 1 });
        var modifiedSha12 = GetFileSHA512(testFile);
        Console.WriteLine("TestSHA12Append: Updated file SHA512:  " + ToHexString(modifiedSha12));
        Console.WriteLine("TestSHA12Append: SHA12 Hashes are: " + (sha12.SequenceEqual(modifiedSha12) ? "EQUAL" : "NOT EQUAL"));
    }
    static void CreateRandomFile(string path, int length)
    {
        // Make some random bytes.
        var randomData = new byte[1024];
        RNGCryptoServiceProvider p = new RNGCryptoServiceProvider();
        p.GetBytes(randomData);
        File.WriteAllBytes(path, randomData);
    }
    
    static void WriteBytes(string path, int fileOffset, byte[] data)
    {
        using (var fileStream = new FileStream(path, FileMode.Open))
        {
            fileStream.Seek(fileOffset, SeekOrigin.Begin);
            fileStream.Write(data, 0, data.Length);
        }
    }
    static void AppendBytes(string path, byte[] data)
    {
        using (var fileStream = new FileStream(path, FileMode.Append))
        {
            fileStream.Write(data, 0, data.Length);
        }
    }
    static byte[] GetFileSHA512(string path)
    {
        using (SHA512 sha = new SHA512Managed())
        {
            return sha.ComputeHash(File.ReadAllBytes(path));
        }
    }
    static string ToHexString(byte[] data)
    {
        return string.Join("", data.Select(b => b.ToString("X2")));
    }
        
