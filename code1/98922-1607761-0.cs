                List<Person> persons = new List<Person> ();
                persons.Add (new Person (1, "test1"));
                persons.Add (new Person (1, "test2"));
                persons.Add (new Person (2, "test3"));
    
                var results = 
                    persons.GroupBy (p => p.AreaId);
    
                foreach( var r in results )
                {
                    Console.WriteLine (String.Format ("Area Id: {0} - Number of members: {1}", r.Key, r.Count ()));
                }
    
                Console.ReadLine ();
