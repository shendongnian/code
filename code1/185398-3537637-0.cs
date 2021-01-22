    public struct MyStruct
    {
        public byte[] data;
        public MyStruct Clone()
        {
            byte[] clonedData = new byte[this.data.Length];
            data.CopyTo(clonedData, 0);
    
            return new MyStruct { data = clonedData };
        }
    }
