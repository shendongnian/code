    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>()
        {
            new Person(){IdPerson = 1, FirstName = "1" },
            new Person(){IdPerson = 2, FirstName = "2" },
            new Person(){IdPerson = 3, FirstName = "3" },
            new Person(){IdPerson = 4},
        };
            
        persons.ForEach(r => {
            r.FirstName = r.FirstName.Checksum().ToString();
        });
    }
