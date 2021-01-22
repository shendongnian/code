    class Program
    {
        static void Main()
        {
            string str = "asdf";
            MakeNull(ref str);
            System.Diagnostics.Debug.Assert(str == null);
        }
    
        static void MakeNull(ref string s)
        {
            s = null;
        }
    
    }
