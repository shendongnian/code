    IdAndString GetIDAndString()
    {
        return new IdAndString()
        {
            ID = 1,
            Str = "123"
        };
    }
    struct IdAndString
    {
        public int ID { get; set; }
        public string Str { get; set; } 
    }
