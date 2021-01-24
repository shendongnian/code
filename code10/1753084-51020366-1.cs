    static void TestSHA12()
    {
        var testFile = Path.GetTempFileName();
        CreateRandomFile(testFile, 1024);
        var sha12 = GetFileSHA512(testFile);
        Console.WriteLine("Original file SHA512: " + ToHexString(sha12));
        // Append 1 byte
        AppendBytes(testFile, new byte[] { 1 });
        var modifiedSha12 = GetFileSHA512(testFile);
        Console.WriteLine("Updated file SHA512:  " + ToHexString(modifiedSha12));
        Console.WriteLine("SHA12 Hashes are: " + (sha12.SequenceEqual(modifiedSha12) ? "EQUAL" : "NOT EQUAL"));
    }
    static void CreateRandomFile(string path, int length)
    {
        // Make some random bytes.
        var randomData = new byte[1024];
        RNGCryptoServiceProvider p = new RNGCryptoServiceProvider();
        p.GetBytes(randomData);
        File.WriteAllBytes(path, randomData);
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
        
