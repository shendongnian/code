    class Program
    {
        delegate void D1();
        delegate string D2();
        static string X() { return null; }
        static void Y(D1 d1) {}
        static void Y(D2 d2) {}
        static void Main()
        {
            Y(X);
        }
    }
