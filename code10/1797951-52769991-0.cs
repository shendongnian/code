        List<person> persons = new List<person>();
        persons.Add(new person() { id = 1, name = "Abel" });
        persons.Add(new person() { id = 1, name = "Joseph" });
        List<person> persons2 = new List<person>();
        persons2.Add(new person() { id = 1, name = "Stacey" });
        persons2.Add(new person() { id = 1, name = "John" });
        SelectList s1 = new SelectList(persons);
        SelectList s2 = new SelectList(persons2);
        SelectList s3 = new SelectList(s1.Union(s2));
