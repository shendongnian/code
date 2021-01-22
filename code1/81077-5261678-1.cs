    void Save()
    {
               Stream bstream = File.Open("c:\\tests\\settings.bin", FileMode.Create);            
                BinaryFormatter bformatter = new BinaryFormatter();
                FieldInfo[] fields = typeof(Settings).GetFields(BindingFlags.Static | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    MemoryStream mem = new MemoryStream();
                    bformatter.Serialize(mem, field.GetValue(null));
                    byte [] bts = mem.GetBuffer();
                    uint length = (uint)bts.Length;
                    bstream.WriteByte((byte)(length & 255)); length >>= 8;
                    bstream.WriteByte((byte)(length & 255)); length >>= 8;
                    bstream.WriteByte((byte)(length & 255)); length >>= 8;
                    bstream.WriteByte((byte)(length & 255)); 
                    bstream.Write(bts, 0, bts.Length);
                    mem.Close();                
                }
                bstream.Close();
    }
    
    void Load()
    {
                Stream bstream2 = File.Open("c:\\tests\\settings.bin", FileMode.Open);
                BinaryFormatter bformatter2 = new BinaryFormatter();
                FieldInfo[] fields = typeof(Settings).GetFields(BindingFlags.Static | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    int length = 0;
                    uint b0 = (uint)bstream2.ReadByte();
                    uint b1 = (uint)bstream2.ReadByte();
                    uint b2 = (uint)bstream2.ReadByte();
                    uint b3 = (uint)bstream2.ReadByte();
    
                    length = (int)((b3 << 24) | (b2 << 16) | (b1 << 8) | b0);                
                    byte[] bts = new byte[length];
                    bstream2.Read(bts, 0, length);
                    MemoryStream mem = new MemoryStream(bts);
                    field.SetValue(null, bformatter2.Deserialize(mem));
                    mem.Close();
                }
                bstream2.Close();
    }
