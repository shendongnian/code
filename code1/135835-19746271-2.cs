    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PersonLogic personLogic = new PersonLogic();
                personLogic.Add(id: "1", age: 24, name: "Dipon", aPersonEntity: new PersonEntity() { Id = "1", Name = "Dipon", Age = 24 });
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error.");
            }
            Console.ReadKey();
        }
    }
