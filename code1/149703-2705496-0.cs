    string filename = "e:\\a.jpg";
            MemoryStream s;
            s = SetTagsInMemory(filename, "test title");
            FileStream fs = new FileStream("e:\\b.jpg", FileMode.CreateNew, FileAccess.ReadWrite);
            BinaryWriter sw = new BinaryWriter(fs);
            s.Seek(0, SeekOrigin.Begin);
            while (s.Position < s.Length)
           {
                byte[] data = new byte[4096];
                s.Read(data, 0, data.Length);
                sw.Write(data);
           }
            
            sw.Flush();
            sw.Close();
            fs.Close();
