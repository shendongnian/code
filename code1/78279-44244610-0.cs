    //note: this is the JLopez answer!!
    /// <summary>
    /// Return size in human readable form
    /// </summary>
    /// <param name="bytes">Size in bytes</param>
    /// <param name="useUnit ">Includes measure unit (default: false)</param>
    /// <returns>Readable value</returns>
    public static string FormatBytes(long bytes, bool useUnit = false)
        {
            string[] Suffix = { " B", " kB", " MB", " GB", " TB" };
            double dblSByte = bytes;
            int i;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }
            return $"{dblSByte:0.##}{(useUnit ? Suffix[i] : null)}";
        }
