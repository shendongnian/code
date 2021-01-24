        public byte[] Serialize()
        {
           using(var s = new MemoryStream())
           using(var w = new BinaryWriter(s))
           {
              w.Write(firstBool);
              w.Write(firstFloat);
              ...
              return s.ToArray();
           }
        }
        
        public void Deserialize(byte[] bytes)
        {
           using(var s = new MemoryStream(bytes))
           using(var r = new BinaryReader(s))
           {
              firstBool = r.ReadBool();
              firstFload = r.ReadFloat();
              ...
           }
        }
