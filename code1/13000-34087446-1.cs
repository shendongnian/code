    /// <summary>
    /// Check if we have valid Image file format.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>true if it's image file</returns>
    public static bool IsValidImageFormat( String path )
    {
        using ( FileStream fs = File.OpenRead(path) )
        {
            byte[] header = new byte[10];
            fs.Read(header, 0, 10);
            foreach ( var pattern in new byte[][] {
                        Encoding.ASCII.GetBytes("BM"),
                        Encoding.ASCII.GetBytes("GIF"),
                        new byte[] { 137, 80, 78, 71 },     // PNG
                        new byte[] { 73, 73, 42 },          // TIFF
                        new byte[] { 77, 77, 42 },          // TIFF
                        new byte[] { 255, 216, 255, 224 },  // jpeg
                        new byte[] { 255, 216, 255, 225 }   // jpeg canon
                } )
            {
                if (pattern.SequenceEqual(header.Take(pattern.Length)))
                    return true;
            }
        }
        return false;
    } //IsValidImageFormat
