    static void Main(string[] args)
    {
        Person person = new Customer(new Employee(new Person(){ Name = "Mathew" }){ Job = "Stocker" }){ IsShopping = true };
        Console.WriteLine(person.Name);
        Console.ReadKey();
    }
    //OUTPUTS
    //Customer, Employee, Mathew
