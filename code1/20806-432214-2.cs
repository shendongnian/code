    // Sample class.  This would be in your main assembly.
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    // Unit tests
    [TestFixture]
    public class PersonTests
    {
        private class PersonComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return (x.Name == y.Name) && (x.Age == y.Age);
            }
    
            public int GetHashCode(Person obj)
            {
                throw new NotImplementedException();
            }
        }
    
        [Test]
        public void Test_PersonComparer()
        {
            Person p1 = new Person { Name = "Tom", Age = 20 }; // Control data
    
            Person p2 = new Person { Name = "Tom", Age = 20 }; // Same as control
            Person p3 = new Person { Name = "Tom", Age = 30 }; // Different age
            Person p4 = new Person { Name = "Bob", Age = 20 }; // Different name.
    
            Assert.IsTrue(new PersonComparer().Equals(p1, p2), "People have same values");
            Assert.IsFalse(new PersonComparer().Equals(p1, p3), "People have different ages.");
            Assert.IsFalse(new PersonComparer().Equals(p1, p4), "People have different names.");
        }
    }
