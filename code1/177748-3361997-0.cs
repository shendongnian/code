    static void Main()
    {
        //This will return the memory usage size for type Int32:
        int size = SizeOf<Int32>();
        //This will return the memory usage size of the variable 'size':
        size = SizeOf(size); 
    }
    public static int SizeOf<T>()
    {
        return System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
    }
    public static int SizeOf(this object obj)
    {
        return System.Runtime.InteropServices.Marshal.SizeOf(obj);
    }
