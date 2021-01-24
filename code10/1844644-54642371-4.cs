    class Category
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Score { get; set; }
        public override string ToString()
        {
            return $"{Name} [Score: {Score}] [Count: {Count}]";
        }
    }
