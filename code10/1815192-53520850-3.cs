     static void CopyStream(System.IO.Stream src, System.IO.Stream dest)
        {
            byte[] buffer = new byte[1024];
            int len;
            while ((len = src.Read(buffer, 0, buffer.Length)) > 0)
                dest.Write(buffer, 0, len);
            dest.Flush();
        }
  
