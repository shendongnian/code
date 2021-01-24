    public class User {
        public int Id {get;set;}
        public List<Owner> Owners {get;set;}
        public List<Pet> Pets {get;set;}
        public User() {
            Owners = new List<Owner>():
            Pets = new List<Pet>():
        }
    }
