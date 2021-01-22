            using (Stream fs = File.OpenRead("gj.txt"))
            {
                using (Stream fd = File.Create("gj.zip"))
                {
                    using (Stream csStream = new GZipStream(fd, CompressionMode.Compress))
                    {
                        byte[] buffer = new byte[1024];
                        int nRead;
                        while ((nRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            csStream.Write(buffer, 0, nRead);
                        }
                    }
                }
            }
            using (Stream fd = File.Create("gj.new.txt"))
            {
                using (Stream fs = File.OpenRead("gj.zip"))
                {
                    using (Stream csStream = new GZipStream(fs, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[1024];
                        int nRead;
                        while ((nRead = csStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fd.Write(buffer, 0, nRead);
                        }
                    }
                }
            }
            using (Stream fd = File.Create("gj.new.txt"))
            {
                using (Stream fs = File.OpenRead("gj.zip"))
                {
                    using (Stream csStream = new GZipStream(fs, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[1024];
                        int nRead;
                        while ((nRead = csStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fd.Write(buffer, 0, nRead);
                        }
                    }
                }
            }
