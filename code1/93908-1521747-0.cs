    public static void CopyText(TextReader input, TextWriter output)
    {
        char[] buffer = new char[8192];
        int length;
        while ((length = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, length);
        }
    }
