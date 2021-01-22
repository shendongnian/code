    var person = new Person()
    Person.Name = "Test";
    Person.Age = 21;
    var PropertyInfo = GetPropertyInfo(person);
    foreach (string key in PropertyInfo.Keys)
    {
         Console.WriteLine("{0} = {1}", key, PropertyInfo[key]);    
    }
