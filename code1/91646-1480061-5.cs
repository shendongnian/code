    public class Person {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int HouseId { get; set; }
        
        private static int LastIdValue { get; set; }
        private static Dictionary<int, Person> People { get; set; }
        
        static Person() {
            LastIdValue = 0;
            People = new Dictionary<int, Person>();
        }
        
        // make the constructor private to disallow direct instantiation
        private Person(int id, string name, int houseId) {
            Id = id;
            Name = name;
            HouseId = houseId;
        }
        
        // only permit construction through this function, which inserts
        // the new Person into the static dictionary before returning it
        static public Person NewPerson(string name, int houseId) {
            Person p = new Person(LastIdValue++, name, houseId);
            People.Add(p.Id, p);
            return p;
        }
        
        static public Person getPersonById(int id) {
            Person p = null;
            return People.TryGetValue(id, out p) ? p : null;
        }
    }
    public class House {
        public int Id { get; private set; }
        public int SquareFootage { get; set; }
        
        private static int LastIdValue { get; set; }
        private static Dictionary<int, House> Houses { get; set; }
        
        static House() {
            LastIdValue = 0;
            Houses = new Dictionary<int, House>();
        }
        
        // make the constructor private to disallow direct instantiation
        private House(int id, int sqft) {
            Id = id;
            SquareFootage = sqft;
        }
        
        // only permit construction through this function, which inserts
        // the new House into the static dictionary before returning it
        static public House NewHouse(int sqft) {
            House h = new House(LastIdValue++, sqft);
            Houses.Add(h.Id, h);
            return h;
        }
        
        static public House getHouseById(int id) {
            House h = null;
            return Houses.TryGetValue(id, out h) ? h : null;
        }
    }
    House firstHouse = House.NewHouse(1000.0);
    House secondHouse = House.NewHouse(2000.0);
    Person dan = Person.NewPerson("Dan", firstHouse.Id);
    Person kat = Person.NewPerson("Kat", firstHouse.Id);
    Person john = Person.NewPerson("John", secondHouse.Id);
    House dansHouse = House.getHouseById(dan.HouseId);
    House katsHouse = House.getHouseById(kat.HouseId);
    // this prints
    if (katsHouse == dansHouse) { Console.WriteLine("Dan and Kat live in the same house."); }
    // this also prints
    if (dansHouse == firstHouse) { Console.WriteLine("Dan and Kat live in the first house."); }
    // this does not print
    if (dansHouse == secondHouse) { Console.WriteLine("Dan and Kat live in the second house."); }
