    var persons = new List<Person>();
    var personInfo = readText.Split(new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
    foreach (var i in personInfo)
    {
    	var person = new Person();
    	var lines = i.Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries);
        person.Name = lines[1].Split(new string[]{": "}, StringSplitOptions.None)[1];
        person.Age = lines[2].Split(new string[]{": "}, StringSplitOptions.None)[1];
    	persons.Add(person);
    }
