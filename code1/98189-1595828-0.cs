    class POCO {
        int aaa;
        double bbb;
        
        public void Read(BinaryReader r) {
            aaa = r.ReadInt32();
            bbb = r.ReadDouble();
        }
        public void Write(BinaryWriter w) {
            w.Write(aaa);
            w.Write(bbb);
        }
    }
