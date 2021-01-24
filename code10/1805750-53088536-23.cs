    static void Main(string[] args)
    {
        //Person person = new Person() { Name = "Mathew" };
        //Console.WriteLine(person.Name);
    
        Person person = new Employee() { Job = "Stocker" };
        Console.WriteLine(person.Name);
    
        person = new Customer(person) { IsShopping = true }
        Console.WriteLine(person.Name); 
    
        Console.ReadKey();
    }
    //OUTPUTS
    //Employee, John Doe
    //Customer, Employee, John Doe
