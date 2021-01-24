    class SomeImmutablePoco
        {
            public SomeImmutablePoco(int pocoId, string name)
            {
     
    
           Id = pocoId;
            Name = name;
        }
    
        [JsonProperty("pocoId")]
        public int Id { get; }
        public string Name { get; }
    }
