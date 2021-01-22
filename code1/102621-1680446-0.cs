            using (var outStream = new FileStream("Out3.zip", FileMode.Create))
            {
                using (var zipStream = new ZipOutputStream(outStream))
                {
                    Crc32 crc = new Crc32();
                    foreach (string pathname in pathnames)
                    {
                        byte[] buffer = File.ReadAllBytes(pathname);
                        ZipEntry entry = new ZipEntry(Path.GetFileName(pathname));
                        entry.DateTime = now;
                        entry.Size = buffer.Length;
                        crc.Reset();
                        crc.Update(buffer);
                        entry.Crc = crc.Value;
                        zipStream.PutNextEntry(entry);
                        zipStream.Write(buffer, 0, buffer.Length);
                    }
                    zipStream.Finish();
                    // I dont think this is required at all
                    zipStream.Flush();
                    zipStream.Close();
                }
            }
