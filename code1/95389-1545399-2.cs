    public static int CountLines(string file, Encoding encoding)
    {
        using (TextReader reader = new StreamReader(file, encoding))
        {
            return CountLines(reader);
        }
    }
    public static int CountLines(TextReader reader)
    {
        char[] buffer = new char[32768];
        
        int charsRead;
        int count = 0;
        
        while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
        {
            for (int i = 0; i < charsRead; i++)
            {
                if (buffer[i] == '\n')
                {
                    count++;
                }
            }
        }
        return count;
    }
