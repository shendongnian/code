    class Program 
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Create();
            var crud = new Crud<Person>();
            
            // Note we're not specifying an ID for *new* entities, the Crud class needs to assign it upon saving
            crud.Create(new Person() { Name = "Someone", Age = 24 });
            crud.Create(new Person() { Name = "Someone2", Age = 24 });
            var list = crud.ReadAll();
            list.ForEach(x => Console.WriteLine("{0} {1}", x.Id, x.Name));
            
            var person1 = list.Single(x => x.Id == 1);
            person1.Name = "Someone3";
            person1.Age = 20;
            Crud.Update(person1);
            Console.ReadKey();
        }
    }
