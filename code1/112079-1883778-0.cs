    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public class Class2
        {
            public int Data;
            public int SomeMoreData;
    
            internal void FromBytes(byte[] p)
            {
                BinaryReader br = new BinaryReader(new MemoryStream(p));
                Data = br.ReadInt32();
                SomeMoreData = br.ReadInt32();
                br.Close();
            }
        }
    
        public class Class1
        {
            public int Action;
            public Class2 Data;
    
            public void FromBytes(byte[] data)
            {
                BinaryReader br = new BinaryReader(new MemoryStream(data));
                Action = br.ReadInt32();
                Data = new Class2();
                int sizeOfClass2Instance = Marshal.SizeOf(Data);
                Data.FromBytes(br.ReadBytes(sizeOfClass2Instance));
                br.Close();
            }
        }
    
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
    
            int[] data = new int[3] { 1, 2, 3 };
            byte[] dataInBytes = new byte[data.Length * sizeof(int)];
    
            for (int i=0;i<data.Length;i++)
            {
                byte[] src = BitConverter.GetBytes(data[i]);
                Array.Copy(src, 0, dataInBytes, i * sizeof(int), sizeof(int));
            }
            c1.FromBytes(dataInBytes);
        }
    }
