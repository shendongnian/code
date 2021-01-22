    class Animal {
        public string Species { get; set; }
    
        public Animal(string species) {
            Species = species;
        }
    }
    
    class Human : Animal {
        public string Name { get; set; }
        
        public Human(string name) : base("Homo sapien") {
            Name = name;
        }
    }
