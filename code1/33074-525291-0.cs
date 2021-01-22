    Person magnus = new Person { Name = "Hedlund, Magnus" };
    Person terry = new Person { Name = "Adams, Terry" };
    Person charlotte = new Person { Name = "Weiss, Charlotte" };
    
    Pet barley = new Pet { Name = "Barley", Owner = terry };
    List<Person> people = new List<Person> { magnus, terry, charlotte };
    List<Pet> pets = new List<Pet>{barley};
    
    var results =
        from person in people
        join pet in pets on person.Name equals pet.Owner.Name into ownedPets
        from ownedPet in ownedPets.DefaultIfEmpty(new Pet())
        orderby person.Name
        select new { OwnerName = person.Name, ownedPet.Name };
    
    
    foreach (var item in results)
    {
        Console.WriteLine(
            String.Format("{0,-25} has {1}", item.OwnerName, item.Name ) );
    }
