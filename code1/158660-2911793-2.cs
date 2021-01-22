    class Person
    {
       public string Name { get; set; }
       public City City { get; set; }
    }
    
    class City
    {
       public string Name { get; set; }
       public string ZipCode { get; set; }
    }
    
    Person person = GetPerson(id);
    
    Console.WriteLine("Person name = {0}", 
          PropertyInspector.GetObjectProperty(person,"Name"));
    
    Console.WriteLine("Person city = {0}",
          PropertyInspector.GetObjectProperty(person,"City.Name"));
