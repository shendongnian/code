    using System;
    
    class Dog
    {
        public String Name { get; set; }
    }
    
    class Example
    {
        static void Main()
        {
            Dog rex = new Dog { Name="Rex" };
            Dog fluffy = new Dog { Name="Fluffy" };
        }
        static void sayHiToDog()
        {
            // In this static method how can I specify which dog instance
            // I mean to access without a valid instance?  It is impossible since
            // the static method knows nothing about the instances that have been
            // created in the static method above.
        }
        static void sayHiToDog(Dog dog)
        {
            // Now this method would work since I now have an instance of the 
            // Dog type that I can say hi to.
            Console.WriteLine("Hello, " + dog.Name);
        }
    } 
