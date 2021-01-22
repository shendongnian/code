        [TestMethod]
        public void Test_Person_Equals_with_ExpectedObjects()
        {
            //use extension method ToExpectedObject() from using ExpectedObjects namespace to project Person to ExpectedObject
            var expected = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
            }.ToExpectedObject();
            var actual = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
            };
            //use ShouldEqual to compare expected and actual instance, if they are not equal, it will throw a System.Exception and its message includes what properties were not match our expectation.
            expected.ShouldEqual(actual);
        }
        [TestMethod]
        public void Test_PersonCollection_Equals_with_ExpectedObjects()
        {
            //collection just invoke extension method: ToExpectedObject() to project Collection<Person> to ExpectedObject too
            var expected = new List<Person>
            {
                new Person { Id=1, Name="A",Age=10},
                new Person { Id=2, Name="B",Age=20},
                new Person { Id=3, Name="C",Age=30},
            }.ToExpectedObject();
            var actual = new List<Person>
            {
                new Person { Id=1, Name="A",Age=10},
                new Person { Id=2, Name="B",Age=20},
                new Person { Id=3, Name="C",Age=30},
            };
            expected.ShouldEqual(actual);
        }
        [TestMethod]
        public void Test_ComposedPerson_Equals_with_ExpectedObjects()
        {
            //ExpectedObject will compare each value of property recursively, so composed type also simply compare equals.
            var expected = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
                Order = new Order { Id = 91, Price = 910 },
            }.ToExpectedObject();
            var actual = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
                Order = new Order { Id = 91, Price = 910 },
            };
            expected.ShouldEqual(actual);
        }
        [TestMethod]
        public void Test_PartialCompare_Person_Equals_with_ExpectedObjects()
        {
            //when partial comparing, you need to use anonymous type too. Because only anonymous type can dynamic define only a few properties should be assign.
            var expected = new
            {
                Id = 1,
                Age = 10,
                Order = new { Id = 91 }, // composed type should be used anonymous type too, only compare properties. If you trace ExpectedObjects's source code, you will find it invoke config.IgnoreType() first.
            }.ToExpectedObject();
            var actual = new Person
            {
                Id = 1,
                Name = "B",
                Age = 10,
                Order = new Order { Id = 91, Price = 910 },
            };
            // partial comparing use ShouldMatch(), rather than ShouldEqual()
            expected.ShouldMatch(actual);
        }
