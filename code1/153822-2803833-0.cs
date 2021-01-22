    public static byte[] Compress(byte[,,] uncompressed)
    {
        using (MemoryStream ms = new MemoryStream())
        using (GZipStream gzs = new GZipStream(ms, CompressionMode.Compress))
        {
            for (int dim = 0; dim < 3; dim++){
                byte[] dimlen = BitConverter.GetBytes(
                                              uncompressed.GetLongLength(dim));
                gzs.Write(dimlen, 0, dimlen.Length);
            }
            long bufferlen = 4096, bufptr = 0;
            byte[] buffer = new byte[bufferlen];
            for (long x = 0; x < uncompressed.GetLongLength(0); x++)
            {
                for (long y = 0; y < uncompressed.GetLongLength(1); y++)
                {
                    for (long z = 0; z < uncompressed.GetLongLength(2); z++)
                    {
                        buffer[bufptr] = uncompressed[x, y, z];
                        
                        if(bufptr == bufferlen)
                            gzs.Write(buffer, 0, (int)bufferlen);
                        bufptr = (bufptr + 1) % bufferlen;
                    }
                }
            }
            gzs.Close();
            return ms.ToArray();
        }
    }
    public static byte[,,] Decompress(byte[] compressed)
    {
        byte[] buffer = new byte[4096];
        byte[] uncompr;
        using (MemoryStream ms = new MemoryStream(compressed))
        using (GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress))
        using (MemoryStream uncompressed = new MemoryStream())
        {
            for (int r = -1; r != 0; r = gzs.Read(buffer, 0, buffer.Length))
                if (r > 0) uncompressed.Write(buffer, 0, r);
            uncompr = uncompressed.ToArray();
        }
        long xdim = BitConverter.ToInt64(uncompr, 0);
        long ydim = BitConverter.ToInt64(uncompr, 8);
        long zdim = BitConverter.ToInt64(uncompr, 16);
        byte[,,] final = new byte[xdim, ydim, zdim];
        long i = 24;
        for (long x = 0; x < xdim; x++)
        {
            for (long y = 0; y < ydim; y++)
            {
                for (long z = 0; z < zdim; z++)
                {
                    if(i < uncompr.Length)
                        final[x, y, z] = uncompr[i];
                    i++;
                }
            }
        }
        return final;
    }
