    class RedactorResult : Dictionary<string, Item>
    {
        private int count = 0;
    
        public void Add(Item item) 
        {
            this[$"file-{count}"] = item;
            count++;
        }
    }
