    using (var stream = ContentResolver.OpenInputStream(fileuri))
    {
           byte[] fileByteArray = ToByteArray(stream); //only once you can read bytes from stream second time onwards it has zero bytes
    
           string fileDestinationPath ="<path of your destination> "
           convertByteArrayToPDF(fileByteArray, fileDestinationPath);//here pdf copied to your destination path
    }
         public static byte[] ToByteArray(Stream stream)
            {
                var bytes = new List<byte>();
    
                int b;
                while ((b = stream.ReadByte()) != -1)
                    bytes.Add((byte)b);
    
                return bytes.ToArray();
            }
    
          public static string convertByteArrayToPDF(byte[] pdfByteArray, string filePath)
            {
    
                try
                {
                    Java.IO.File data = new Java.IO.File(filePath);
                    Java.IO.OutputStream outPut = new Java.IO.FileOutputStream(data);
                    outPut.Write(pdfByteArray);
                    return data.AbsolutePath;
    
                }
                catch (System.Exception ex)
                {
                    return string.Empty;
                }
            }
