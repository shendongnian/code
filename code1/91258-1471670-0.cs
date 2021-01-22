    public class IntList
    {
        public IntList(IEnumerable<int> source)
        {
            items = source.ToArray();
            Squares = new SquareList(this);
        }
    
        private int[] items;
    
        // The indexer everyone else mentioned
        public int this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        
        // Other properties might be useful:
        public SquareList Squares { get; private set; }
    
        public class SquareList
        {
            public SquareList(IntList list)
            {
                this.list = list;
            }
    
            private IntList list;
    
            public int this[int index]
            {
                get { return list.items[index] * list.items[index]; }
            }
        }
    }
