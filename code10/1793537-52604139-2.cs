    public static async Task<char[]> ReadCharsAsync(string filename, int count)
    {
        using (var stream = File.OpenRead(filename))
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
            char[] buffer = new char[count];
            int n = await reader.ReadBlockAsync(buffer, 0, count);
            char[] result = new char[n];
            Array.Copy(buffer, result, n);
            return result;
        }
    }
