    static class Test
    {
        static void Main()
        {
            //This will return the memory usage size for type Int32:
            int size = SizeOf<Int32>();
    
            //This will return the memory usage size of the variable 'size':
            //Both lines are basically equal, the first one makes use of ex. methods
            size = size.GetSize();
            size = GetSize(size);
        }
    
        public static int SizeOf<T>()
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
        }
    
        public static int GetSize(this object obj)
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(obj);
        }
    }
