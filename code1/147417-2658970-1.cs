    public class Person
    {
        public static int Age;
        public string Name;
    
        public Person( int age, string name )
        {
            Age = age;
            Name = name;
        }
    
        public void Speak()
        {
            Console.WriteLine( "My name is {0} and I'm {1} years old.", Name, Age );
        }
    
    }
    
    public class StaticDemo
    {
    
        static void Main( string[] args )
        {
            var fizz = new Person( 25, "Fizz" );
            fizz.Speak();
            var buzz = new Person( 30, "Buzz" );
            buzz.Speak();
    
            var people = new List<Person>
            {
              fizz,
              buzz,
              new Person( 35, "Foo" ),
              new Person( 40, "Bar" ),
            };
    
            foreach( Person person in people )
            {
                person.Speak();
            }
    
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine( "--done--" );
            Console.ReadLine();
    
        }
    
    }
