    public static void PrependString(string value, FileStream file)
    {
         var buffer = new byte[file.Length];
         while (file.Read(buffer, 0, buffer.Length) != 0)
         {
         }
         if(!file.CanWrite)
             throw new ArgumentException("The specified file cannot be written.", "file");
         file.Position = 0;
         var data = Encoding.Unicode.GetBytes(value);
         file.SetLength(buffer.Length + data.Length);
         file.Write(data, 0, data.Length);
         file.Write(buffer, 0, buffer.Length);
     }
     public static void Prepend(this FileStream file, string value)
     {
         PrependString(value, file);
     }
