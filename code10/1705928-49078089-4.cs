    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("y value of index 1 is: {0}", General.b[1].y);
            Console.ReadLine();
        }
    }
    
    public static class General
    {
        public static a[] b = new a[] { new a() { x = 0, y = 0, z = new byte[] { 0, 0, 0 }},
                                        new a() { x = 1, y = 1, z = new byte[] { 1, 1, 1 }}
            };
        public struct a
        {
            public int x;
            public int y;
            public byte[] z;
        }
    }
    
     
