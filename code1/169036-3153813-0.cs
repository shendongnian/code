    using ICSharpCode.SharpZipLib.BZip2;
    
        public static string Unzip(byte[] compressedbytes)
                {
                    string result;
                    MemoryStream m_msBZip2 = null;
                    BZip2InputStream m_isBZip2 = null;
        
                    m_msBZip2 = new MemoryStream(compressedbytes);
                    // read final uncompressed string size stored in first 4 bytes
                    using (BinaryReader reader = new BinaryReader(m_msBZip2, System.Text.Encoding.ASCII))
                    {
                        Int32 size = reader.ReadInt32();
        
                        m_isBZip2 = new BZip2InputStream(m_msBZip2);
                        byte[] bytesUncompressed = new byte[size];
                        m_isBZip2.Read(bytesUncompressed, 0, bytesUncompressed.Length);
                        m_isBZip2.Close();
                        m_msBZip2.Close();
        
                        result = Encoding.ASCII.GetString(bytesUncompressed, 0, bytesUncompressed.Length);
        
                        reader.Close();
                    }
        
                    return result;
                }
        
                public static byte[] Zip(string sBuffer)
                {
        
                    byte[] result;
        
                    using (MemoryStream m_msBZip2 = new MemoryStream())
                    {
                        Int32 size = sBuffer.Length;
                        // Prepend the compressed data with the length of the uncompressed data (firs 4 bytes)
                        using (BinaryWriter writer = new BinaryWriter(m_msBZip2, System.Text.Encoding.ASCII))
                        {
                            writer.Write(size);
        
                            using (BZip2OutputStream m_osBZip2 = new BZip2OutputStream(m_msBZip2))
                            {
                                m_osBZip2.Write(Encoding.ASCII.GetBytes(sBuffer), 0, sBuffer.Length);
                                m_osBZip2.Close();
                            }
        
                            writer.Close();
                            result = m_msBZip2.ToArray();
        
                            m_msBZip2.Close();
                        }
                    }
        
                    return result;
                }
