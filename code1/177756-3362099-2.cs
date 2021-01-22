    struct s
    {
        public Int64 i;
    }
    
    public static void Main()
    {
        s s1;
        s1.i = 10;          
        var s = System.Runtime.InteropServices.Marshal.SizeOf(s1);
    }
