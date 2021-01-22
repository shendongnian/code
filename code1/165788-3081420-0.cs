    using (BinaryReader r = new BinaryReader(ImageFile.InputStream))
                {
                    byte buffer = r.ReadByte();
                    fileclass = buffer.ToString();
                    buffer = r.ReadByte();
                    fileclass += buffer.ToString();
                    r.Close();
                }
