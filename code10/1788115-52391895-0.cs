    using System;
    
    namespace Demo
    {
        class Program
        {
            interface IAwesomeInterface
            {
                void DoSomething(int number);
                void DoSomething(string strang);
                void DoSomething(Person person);
            }
    
            class MyClass : IAwesomeInterface
            {
                public void DoSomething(int number)
                {
                    number = number + 100;
                    Console.WriteLine(number);
                }
    
                public void DoSomething(string strang)
                {
                    strang += " World";
                    Console.WriteLine(strang);
                }
    
                public void DoSomething(Person person)
                {
                    person.Id = person.Id++;
                    person.Name += "Bar";
    
                    Console.WriteLine($"{person.Id} - {person.Name}");
                }
            }
            
            static void Main(string[] args)
            {
                int someNumber = 3;
    
                string strang = "Hello";
    
                Person person = new Person();
                person.Id = 1;
                person.Name = "Foo";
    
                MyClass myClass = new MyClass();
    
                // Do something with a number
                myClass.DoSomething(someNumber);
    
                // Do something with a strang (string)
                myClass.DoSomething(strang);
    
                // Do something with a Person object
                myClass.DoSomething(person);
    
                Console.ReadKey();
            }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
