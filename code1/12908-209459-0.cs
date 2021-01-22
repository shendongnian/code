    class Tree
    {
        public event EventHandler MadeSound = delegate {};
    
        public void Fall() { MadeSound(this, new EventArgs()); }
    
        static void Main(string[] args)
        {
            Tree oaky = new Tree();
            oaky.Fall();
        }
    }
