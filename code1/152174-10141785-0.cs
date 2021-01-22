    public static byte[] ZipToUnzipBytes(byte[] bytesContext)
            {
                byte[] arrUnZipFile = null;
                if (bytesContext.Length > 100)
                {
                    using (var inFile = new MemoryStream(bytesContext))
                    {
                        using (var decompress = new GZipStream(inFile, CompressionMode.Decompress, false))
                        {
                            byte[] bufferWrite = new byte[4];
                            inFile.Position = (int)inFile.Length - 4;
                            inFile.Read(bufferWrite, 0, 4);
                            inFile.Position = 0;
                            arrUnZipFile = new byte[BitConverter.ToInt32(bufferWrite, 0) + 100];
                            decompress.Read(arrUnZipFile, 0, arrUnZipFile.Length);
                        }
                    }
                }
                return arrUnZipFile;
            }
