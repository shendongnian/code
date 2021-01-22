    public class Person {
        public string Name { get; set; }
        public static House House { get; set; }
       
        public Person(string name, House house) {
            Name = name;
            House = house;
        }
       
        public override string ToString() {
            return String.Concat(Name, ", ", House);
        }
    }
    public class House {
        public double SquareFootage { get; set; }
       
        public House(double sqft) { SquareFootage = sqft; }
       
        public override string ToString() {
            return String.Format("House - {0} sq. ft.", SquareFootage);
        }
    }
    House danAndKatsHouse = new House(1000.0);
    House johnsHouse = new House(2000.0);
    Person dan = new Person("Dan", danAndKatsHouse);
    // outputs "Dan, House - 1000 sq. ft." as expected
    Console.WriteLine(dan);
    Person kat = new Person("Kat", danAndKatsHouse);
    // outputs "Kat, House - 1000 sq. ft.", again as expected
    Console.WriteLine(kat);
    Person john = new Person("John", johnsHouse);
    // outputs "John, House - 2000 sq. ft.", so far so good...
    Console.WriteLine(john);
    // but what's this? suddenly dan and kat's house has changed?
    // outputs "Dan, House - 2000 sq. ft."
    Console.WriteLine(dan);
