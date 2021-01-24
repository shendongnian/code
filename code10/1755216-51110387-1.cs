    public class Foo
    {
        public string FooStr { get; set; }
        public Dictionary<string, PetObject> Pets { get; set; }
        // if you still need a list of pets, use this
        public List<PetObject> PetObjects => Pets.Values.ToList();
    }
