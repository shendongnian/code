    static void Main(string[] args)
    {
        b.methoda();
    }
    class a
    {
        public static void methoda()
        {
            //using initialized method data
        }
    }
    class b : a
    {
        static b()
        {
            //some initialization
        }
    }    
    
    
