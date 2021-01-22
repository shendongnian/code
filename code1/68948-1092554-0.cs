        public void TestPassing()
        {
            int[] stuff = new int[] {5, 5, 5, 5};
            Add(stuff, 5);
            for (int i = 0; i < stuff.Length; i++)
            {
                Console.Write(stuff[i]);
            }
        }
        public void Add(int[] stuff, int x)
        {
            for(int i = 0; i < stuff.Length; i++)
            {
                stuff[i] = stuff[i] + x;
            }
        }
