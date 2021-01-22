    class foo
    {
        public MemoryStream MyMemory { get; set; }
    
        public void Write(string s)
        {
            MyMemory.Write(System.Text.Encoding.ASCII.GetBytes(s));
        }
    
        [STAThread]
        static void Main()
        {
            foo f = new foo();
            f.MyMemory = new System.IO.MemoryStream();
            
            f.Write("information");
        }
    
    }
