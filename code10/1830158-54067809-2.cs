    public class Owner {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Country {get;set}
    }
    public class Pet {
        public int Id { get; set; }
        public string Animal { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; } 
    }
    public class User {
        public int Id {get;set;}
        public List<Owner> Owners {get;set;}
        public List<Pet> Pets {get;set}
    }
