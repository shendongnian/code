    public class FooObject
    {
        [JsonProperty("foo")]
        public string Foo { get; set; }
        [JsonProperty("pets")]
        public Dictionary<string, PetObject> Pets { get; set; }
        // if you still need a list of pets, use this
        public List<PetObject> PetsList => Pets.Values.ToList();
    }
