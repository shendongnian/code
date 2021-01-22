        [DllImport("Native_CPP.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern double Add(double a, double b); 
    
        static void Main(string[] args)
        {
            Console.WriteLine(Add(1.0, 3.0));
    
            Console.ReadLine();
        }
