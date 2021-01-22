                FileStream fZip = File.Create(compressedOutputFile);
                ZipOutputStream zipOStream = new ZipOutputStream(fZip);
                foreach (FileInfo fi in allfiles)
                {
                    ZipEntry entry = new ZipEntry((fi.Name));
                    zipOStream.PutNextEntry(entry);
                    FileStream fs = File.OpenRead(fi.FullName);
                    try
                    {
                        byte[] transferBuffer[1024];
                        do
                        {
                            bytesRead = fs.Read(transferBuffer, 0, transferBuffer.Length);
                            zipOStream.Write(transferBuffer, 0, bytesRead);
                        }
                        while (bytesRead > 0);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
                zipOStream.Finish();
                zipOStream.Close();
