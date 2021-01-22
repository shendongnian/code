    public static void CopySection(Stream input, string targetFile,
                                   int length, byte[] buffer)
    {
        using (Stream output = File.OpenWrite(targetFile))
        {
            int bytesRead = 1;
            // This will finish silently if we couldn't read "length" bytes.
            // An alternative would be to throw an exception
            while (length > 0 && bytesRead > 0)
            {
                bytesRead = input.Read(buffer, 0, Math.Min(length, buffer.Length));
                output.Write(buffer, 0, bytesRead);
                length -= bytesRead;
            }
        }
    }
