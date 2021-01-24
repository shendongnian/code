    public static void Main()
    {
        Console.WriteLine("Program Started!");
        List<person> person1 = new List<person>();
        person1.Add(new person(10, "P1" ));
        person1.Add(new person( 11, "Q1" ));
        person1.Add(new person(12,  "R1" ));
        List<person> person2 = new List<person>();
        foreach(person p in person1)
        {
            person2.Add(new person(p)); //WE COPY BY VALUE. BY ALLOCATING SPACE FOR A NEW OBJECT.
        }
        person2[0].name = "P2";
        Console.WriteLine("---------Person1---------");
        foreach (person P in person1)
        {
            Console.WriteLine("Age=" + P.age);
            Console.WriteLine("Name=" + P.name);
        }
        Console.WriteLine("---------Person2---------");
        foreach (person P in person2)
        {
            Console.WriteLine("Age=" + P.age);
            Console.WriteLine("Name=" + P.name);
        }
        Console.WriteLine("Program Ended!");
        Console.ReadKey();
    }
    public class person
    {
        public int age;
        public string name;
        public person(person p) {
            this.age = p.age;
            this.name = p.name;
        }
        public person(int _age, string _name)
        {
            this.age = _age;
            this.name = _name;
        }
    }
