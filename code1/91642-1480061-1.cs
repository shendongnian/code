    public class Person {
        public static string Name { get; set; }
       
        public Person(string name) { Name = name; }
        
        public override string ToString() {
            return Name;
        }
    }
    Person dan = new Person("Dan";
    Person john = new Person("John";
    // outputs "John"
    Console.WriteLine(john);
    // outputs "John" again, since Dan doesn't have a name property all his own
    // (and neither does John, for that matter)
    Console.WriteLine(dan);
