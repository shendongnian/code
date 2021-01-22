        static void Main(string[] args)
        {
            b obj = new b();
            obj.item1 = 4;// should show an error but it doent ???
        }
    }
    class baseA
    {
        public int item2 { get; set; }
    }
    class a:baseA
    {
        public int item1 { get; set; }        
    }
    class b : baseA
    {        
    }
    class c : a
    {
    }
