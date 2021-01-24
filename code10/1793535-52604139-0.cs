    public static char[] ReadChars(string filename, int count)
    {
        using (var stream = File.OpenRead(filename))
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
            char[] buffer = new char[count];
            int n = reader.ReadBlock(buffer, 0, count);
            char[] result = new char[n];
            Array.Copy(buffer, result, n);
            return result;
        }
    }
