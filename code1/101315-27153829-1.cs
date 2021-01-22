    dynamic person = new ExpandoObject();
    person.FirstName = "Dino";
    person.LastName = "Esposito";
    
    person.GetFullName = (Func<String>)(() => { 
      return String.Format("{0}, {1}", 
        person.LastName, person.FirstName); 
    });
    
    var name = person.GetFullName();
    Console.WriteLine(name);
