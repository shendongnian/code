    class Test
    {
        private string[,] cells;
        
        public Test(int height, int width)
        {
            cells = new string[height, width];
        }
        
        // This is where it gets interesting : this will be called when you access your class, for example, like this :
        // Test t = new Test(5, 5);
        // t[2, 3] = "test"; => set will be called
        // or 
        // Console.WriteLine(t[2, 3]); => get will be called
        public string this[int y, int x]
        {
            get
            {
                 return cells[y, x];
            }
            set
            {
               cells[y, x] = value; // Value is the part which is after the "="
            }
        }
    }
