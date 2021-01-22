    IList<Person> list = new List<Person>();
	
	list.Add(new Person("David","Beckham"));
	list.Add(new Person("Gennaro","Gattuso"));
	list.Add(new Person("Cristian","Carlesso"));
	
	list = list.Sort(SortOrder.Descending, X => X.Name);
            
            
    
