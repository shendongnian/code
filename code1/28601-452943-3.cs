    public static IEnumerable<string> readFile()
    {
        using (FileStream reader = new FileStream(@"c:\test.txt",FileMode.Open,FileAccess.Read))
        {
            int i=0;
            StringBuilder lineBuffer = new StringBuilder();
            int byteRead;
            while (-i < reader.Length)
            {
                reader.Seek(--i, SeekOrigin.End);
                byteRead = reader.ReadByte();
                if (byteRead == 10 && lineBuffer.Length > 0)
                {
                    yield return Reverse(lineBuffer.ToString());
                    lineBuffer.Remove(0, lineBuffer.Length);
                }
                lineBuffer.Append((char)byteRead);
            }
            yield return Reverse(lineBuffer.ToString());
            reader.Close();
        }
    }
    public static string Reverse(string str)
    {
        char[] arr = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
            arr[i] = str[str.Length - 1 - i];
        return new string(arr);
    }
