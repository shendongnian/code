    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace L2STest
    {
        public class Sport
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        public class SportPerPerson
        {
            public int Id { get; set; }
            public int PersonId { get; set; }
            public int SportId { get; set; }
        }
    
        [TestClass]
        public class SportsTest
        {
            private List<Person> persons;
            private List<Sport> sports;
            private List<SportPerPerson> sportsPerPerson;
    
             [TestInitialize]
             public void MyTestInitialize()
             {
                 persons = new List<Person>
                 {
                     new Person {Id = 1, FirstName = "John", LastName = "Doe"},
                     new Person {Id = 2, FirstName = "Peter", LastName = "Svendson"},
                     new Person {Id = 3, FirstName = "Ola", LastName = "Hansen"},
                     new Person {Id = 4, FirstName = "Marv", LastName = "Petterson"},
                 };
    
                 sports = new List<Sport>
                 {
                     new Sport {Id = 1, Name = "Tennis"},
                     new Sport {Id = 2, Name = "Soccer"},
                     new Sport {Id = 3, Name = "Hockey"},
                 };
    
                 sportsPerPerson = new List<SportPerPerson>
                 {
                     new SportPerPerson {Id = 1, PersonId = 1, SportId = 1}, 
                     new SportPerPerson {Id = 2, PersonId = 1, SportId = 3}, 
                     new SportPerPerson {Id = 3, PersonId = 2, SportId = 2}, 
                     new SportPerPerson {Id = 4, PersonId = 2, SportId = 3}, 
                     new SportPerPerson {Id = 5, PersonId = 3, SportId = 2}, 
                     new SportPerPerson {Id = 6, PersonId = 3, SportId = 1}, 
                     new SportPerPerson {Id = 7, PersonId = 4, SportId = 2}, 
                     new SportPerPerson {Id = 8, PersonId = 4, SportId = 3}, 
                 };
             }
     
            [TestMethod]
            public void QueryTest()
            {
                var sportIds = sports
                    .Where(s => s.Name == "Hockey" || s.Name == "Soccer")
                    .Select(s => s.Id);
    
                var people = persons.Where(p => sportsPerPerson
                    .Count(spp => (spp.PersonId == p.Id)
                    && sportIds.Contains(spp.SportId)) == 2); 
    
                Assert.AreEqual(2, people.Count());
                Assert.AreEqual("Peter", people.First().FirstName);
                Assert.AreEqual("Marv", people.Last().FirstName);
            }
        }
    }
