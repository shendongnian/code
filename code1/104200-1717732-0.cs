        public void WriteTo(BinaryWriter writer)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(value1);
            bw.Write(value2);
            bw.Write(value3);
            bw.Write(value4);
            writer.Write(ms.ToArray());
        }
