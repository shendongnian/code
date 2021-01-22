    public static class StreamCopier
    {
       public static void
       CopyTo (this Stream from, Stream to)
       {
          if (!from.CanRead || !to.CanWrite)
          {
             return;
          }
    
          var  buffer = from.CanSeek
             ? new byte [from.Length]
             : new byte [DefaultStreamChunkSize];
          int  read;
    
          while ((read = from.Read (buffer, 0, buffer.Length)) > 0)
          {
            to.Write (buffer, 0, read);
          }
       }
    
       private const long DefaultStreamChunkSize = 0x1000;
    }
