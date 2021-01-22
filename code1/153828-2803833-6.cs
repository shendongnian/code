    public static byte[] Compress(byte[, ,] uncompressed)
    {
        if (uncompressed == null)
            throw new ArgumentNullException("The given array is null!");
        if (uncompressed.LongLength > (long)int.MaxValue)
            throw new ArgumentException("The given array is too large!");
        using (MemoryStream ms = new MemoryStream())
        using (GZipStream gzs = new GZipStream(ms, CompressionMode.Compress))
        {
            // Save sizes of the dimensions
            for (int dim = 0; dim < 3; dim++)
                gzs.Write(BitConverter.GetBytes(
                          uncompressed.GetLength(dim)), 0, sizeof(int));
            // Convert byte[,,] to byte[] by just blockcopying it
            // I know, some pointer-magic/unmanaged cast wouldnt 
            // have to copy it, but its cleaner this way...
            byte[] data = new byte[uncompressed.Length];
            Buffer.BlockCopy(uncompressed, 0, data, 0, uncompressed.Length);
            // Write the data to the stream to compress it
            gzs.Write(data, 0, data.Length);
            gzs.Close();
            // Get the compressed byte array back
            return ms.ToArray();
        }
    }
