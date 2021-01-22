        private string UnZipFile(string file, string dirToUnzipTo)
        {
            string unzippedfile = "";
            try
            {
                using(Stream inStream = File.OpenRead(file))
                using (ZipInputStream s = new ZipInputStream(inStream))
                {
                    ZipEntry myEntry;
                    byte[] data = new byte[4096];
                    while ((myEntry = s.GetNextEntry()) != null)
                    {
                        string fileWDir = Path.Combine(dirToUnzipTo, myEntry.Name);
                        string dir = Path.GetDirectoryName(fileWDir);
                        // note only supports a single level of sub-directories...
                        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                        unzippedfile = fileWDir; // note; returns last file if multiple
                        using (FileStream outStream = File.Create(fileWDir))
                        {
                            int size;
                            while ((size = s.Read(data, 0, data.Length)) > 0)
                            {
                                outStream.Write(data, 0, size);
                            }
                            outStream.Close();
                        }
                    }
                    s.Close();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return (unzippedfile);
        }
