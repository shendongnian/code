    private static string FormatBytes(long bytes)
    {
        string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
        int i = 0;
        double dblSByte = bytes;
        if (bytes > 1024)
          for (i = 0; (bytes / 1024) > 0; i++, bytes /= 1024)
            dblSByte = bytes / 1024.0;
        return String.Format("{0:0.##}{1}", dblSByte, Suffix[i]);
    }
    
