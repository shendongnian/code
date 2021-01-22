    public static byte[] ReadFully (Stream stream)
    {
       byte[] buffer = new byte[32768];
       using (MemoryStream ms = new MemoryStream())
       {
           while (true)
           {
               int read = stream.Read (buffer, 0, buffer.Length);
               if (read <= 0)
                   return ms.ToArray();
               ms.Write (buffer, 0, read);
           }
       }
    }
