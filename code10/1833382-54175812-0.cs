    class Item
    {
        public int id { get; set; }
        public string result { get; set; }
        public override string ToString()
        {
            return $"{result}{id}";
        }
    }
