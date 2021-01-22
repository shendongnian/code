    public static dynamic GetPerson()
    {
        dynamic person = new ExpandoObject();
        person.Name = "Foo";
        person.Age = 30;
       
        return person;
    }
