    public struct MyStruct
        {
            public byte MyByte;
            public NestedStruct MyNestedStruct;
    
            public struct NestedStruct
            {
                public byte NestedStructByte;
            }
    
            public MyStruct(byte[] bytes)
            {
                MyByte = bytes[0];
                MyNestedStruct.NestedStructByte = bytes[1];
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyStruct ms = new MyStruct(new byte[] { 1, 2 });
                //ms.MyByte; // 0, but should be 1
                //ms.MyNestedStruct.NestedStructByte; // 0, but should be 2
    
            }
        }
