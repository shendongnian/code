    class Program
    {
        static void Main(string[] args)
        {
            // D derives from C which implements interface IA and IB which 
            // are both derived from IMatrix
            var matrix = new D {Height = 100, Width = 200};
            // Method takes IMatrix
            X(matrix);
            // Method takes IA
            Y(matrix);
            // Method takes IB
            Z(matrix);
            // Method takes D
            LastTest(matrix);
            //
            //  Prints heights and widths 4 times
            //
        }
        static void X(IMatrix x)
        {
            Console.WriteLine(string.Format("Height: {0}\r\nWidth: {1}\r\n\r\n", 
            x.Height, x.Width));
        }
        static void Y(IA x)
        {
            Console.WriteLine(string.Format("Height: {0}\r\nWidth: {1}\r\n\r\n", 
            x.Height, x.Width));
        }
        static void Z(IB x)
        {
            Console.WriteLine(string.Format("Height: {0}\r\nWidth: {1}\r\n\r\n", 
            x.Height, x.Width));
        }
        static void LastTest(D x)
        {
            Console.WriteLine(string.Format("Height: {0}\r\nWidth: {1}\r\n\r\n", 
            x.Height, x.Width));
        }
    }
    internal interface IMatrix
    {
        int Width { get; set; }
        int Height { get; set; }   
    }
    internal interface IA : IMatrix
    {}
    internal interface IB : IMatrix
    {}
    internal class C : IA
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    internal class D : IA, IB
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
