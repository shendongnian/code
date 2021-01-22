    private class Template
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    
        public override string ToString()
        {
            return this.Name;
        }
    }
