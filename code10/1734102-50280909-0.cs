        string fileToZipPath = @"c:\users\exampleuse\binaryfile.exe"; 
        using (FileStream zipToOpen = new FileStream(@"c:\users\exampleuse\release.zip", FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                ZipArchiveEntry readmeEntry = archive.CreateEntry("BinaryFile.exe");
                using (Stream writer = readmeEntry.Open())
                {
                    using (FileStream fileToCompress = new FileStream (fileToZipPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        byte[] buf = new byte[4096];
                        int bytesRead = 1;
                        while (bytesRead > 0)
                        {
                            bytesRead = fileToCompress.Read(buf, 0, buf.Length);
                            writer.Write(buf, 0, bytesRead);
                        }
                    }
                }
            }
        }
