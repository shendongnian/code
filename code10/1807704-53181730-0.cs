    public class Breed
    {
        public string Name { get; set; }
    }
    public class Animal
    {
        public string Name { get; set; }
        public Breed Breed { get; set; }
    }
    public class Circus
    {
        public string Name { get; set; }
    }
    public class Contract
    {
        public Animal Performer { get; set; }
        public Circus Venue { get; set; }
    }
