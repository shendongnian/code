        List<Person> personList = new List<Person>();
        Random rand = new Random();
        
        //generate 50 random persons
        for (int i = 0; i < 50; i++)
        {
            Person p = new Person();
            p.Attributes = new List<PersonAttribute>();
            p.Attributes.Add(new PersonAttribute() { ID = 8, Name = "Age", Value = rand.Next(0, 100).ToString() });
            p.Attributes.Add(new PersonAttribute() { ID = 10, Name = "Name", Value = rand.Next(0, 100).ToString() });
            personList.Add(p);
        }
        
        var finalList = personList.OrderBy(c => c.Attributes.Find(a => a.Name == "Age").Value).ToList();
