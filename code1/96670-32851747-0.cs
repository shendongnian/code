        private List<Person> persons = List<Person>();
        
                public PersonService()
                {
                    persons = new List<Person>() { 
                        new Person { Id = 1, DOB = DateTime.Today, FirstName = "Pawan", LastName = "Shakya" },
                        new Person { Id = 2, DOB = DateTime.Today, FirstName = "Bibek", LastName = "Pandey" },
                        new Person { Id = 3, DOB = DateTime.Today, FirstName = "Shrestha", LastName = "Prami" },
                        new Person { Id = 4, DOB = DateTime.Today, FirstName = "Monika", LastName = "Pandey" },
                    };
                }
    
    public PersonRepository.Interface.Person GetPerson(string lastName)
            {
                return persons[persons.FindIndex(p=>p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))];
            }
