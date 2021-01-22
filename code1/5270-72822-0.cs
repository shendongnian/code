    public Byte[] ConvertToBytes(Char[] source)
    {
        Byte[] result = new Byte[source.Length * sizeof(Char)];
        IntPtr tempBuffer = Marshal.AllocHGlobal(result.Length);
        try
        {
            Marshal.Copy(source, 0, tempBuffer, source.Length);
            Marshal.Copy(tempBuffer, result, 0, result.Length);
        }
        finally
        {
            Marshal.FreeHGlobal(tempBuffer);
        }
        return result;
    }
  
