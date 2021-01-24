    class Data
    {
        public Data(string id, string size, int value, string color)
        {
            Id = id;
            Size = size;
            Color = color;
            Value = value;
        }
        
        public string Id {get;set;}
        
        public string Size {get;set;}
        
        public int Value {get;set;}
        
        public string Color {get;set;} 
        
        public override string ToString()
        {
            return string.Format("Id = {0}, Size = {1}, Value = {2}, Color = {3}", Id, Size, Value, Color);
        }
    }
