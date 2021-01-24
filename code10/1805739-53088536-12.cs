    static void Main(string[] args)
    {
        Person person = new Person() { Name = "Mathew" };
        Console.WriteLine(person.Name);
    
        person = new Employee(person) { Job = "Stocker" };
        Console.WriteLine(person.Name);
    
        person = new Customer(person) { IsShopping = true };
        Console.WriteLine(person.Name); 
    
        Console.ReadKey();
    }
    //OUTPUTS
    //Mathew
    //Employee, Mathew
    //Customer, Employee, Mathew
