    public class Person
    {
        public Person() {
        }
    
        public String Name { get; set; }
        public DateTime DOB { get; set; }
    }
    Person p = 
        from person in db.People 
        where person.Id = 1 
        select new Person { 
            Name = person.Name,
            DOB = person.DateOfBirth
        }
