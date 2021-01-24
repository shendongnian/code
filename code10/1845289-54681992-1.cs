    foreach (var file in files)
                    {
                        clientContext.Load(file);
                        Console.WriteLine(file.Name);
                        ClientResult<Stream> stream = file.OpenBinaryStream();
                        clientContext.ExecuteQuery();
                        var fileOut = Path.Combine(localPath, file.Name);
    
                        if (!System.IO.File.Exists(fileOut))
                        {
                            using (Stream fileStream = new FileStream(fileOut, FileMode.Create))
                            {
                                CopyStream(stream.Value, fileStream);
                            }
                        }
                    }
    
    private static void CopyStream(Stream src, Stream dest)
        {
            byte[] buf = new byte[8192];
            for (; ; )
            {
                int numRead = src.Read(buf, 0, buf.Length);
                if (numRead == 0)
                    break;
                dest.Write(buf, 0, numRead);
            }
        }
