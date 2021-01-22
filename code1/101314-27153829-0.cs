    dynamic person = new ExpandoObject();
    expando.FirstName = "Dino";
    expando.LastName = "Esposito";
    
    person.GetFullName = (Func<String>)(() => { 
      return String.Format("{0}, {1}", 
        person.LastName, person.FirstName); 
    });
    
    var name = person.GetFullName();
    Console.WriteLine(name);
