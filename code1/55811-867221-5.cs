    List<Person> peopleArray = new List<Person>();
                peopleArray.Add(new Person(1, "Jerry", 1));
            peopleArray.Add(new Person(2, "George", 4));
            peopleArray.Add(new Person(3, "Elaine", 3));
            peopleArray.Add(new Person(4, "Kramer", 2));    
                peopleArray.Sort();
    
                foreach (Person p in peopleArray)
                    Console.WriteLine(p.parentID);
