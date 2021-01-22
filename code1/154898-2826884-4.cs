    /// <summary>
    /// Ensures that file exists and retrieves the content type 
    /// </summary>
    /// <param name="file"></param>
    /// <returns>Returns for instance "images/jpeg" </returns>
    public static string getMimeFromFile(string file)
    {
        IntPtr mimeout;
        if (!System.IO.File.Exists(file))
        throw new FileNotFoundException(file + " not found");
        int MaxContent = (int)new FileInfo(file).Length;
        if (MaxContent > 4096) MaxContent = 4096;
        FileStream fs = File.OpenRead(file);
        byte[] buf = new byte[MaxContent];        
        fs.Read(buf, 0, MaxContent);
        fs.Close();
        int result = FindMimeFromData(IntPtr.Zero, file, buf, MaxContent, null, 0, out mimeout, 0);
        if (result != 0)
        throw Marshal.GetExceptionForHR(result);
        string mime = Marshal.PtrToStringUni(mimeout);
        Marshal.FreeCoTaskMem(mimeout);
        return mime;
    }
