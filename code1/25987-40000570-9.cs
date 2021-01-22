    /// <summary>
    /// Copies the contents of input to output. Doesn't close either stream.
    /// </summary>
    public static void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ( (len = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, len);
        }    
    }
    public static void WriteFile(string fileName, Stream inputStream)
    {
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!path.EndsWith(@"\")) path += @"\";
        if (File.Exists(Path.Combine(path, fileName)))
            File.Delete(Path.Combine(path, fileName));
        using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.CreateNew, FileAccess.Write)
        {
            CopyStream(inputStream, fs);
            fs.Close();
        }
        inputStream.Close();
        inputStream.Flush();
    }
