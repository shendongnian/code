    public class Foo
    {
        public string Foo { get; set; }
        public Dictionary<string, PetObject> Pets { get; set; }
        // if you still need a list of pets, use this
        public List<PetObject> PetObjects => pets.Values.ToList();
    }
