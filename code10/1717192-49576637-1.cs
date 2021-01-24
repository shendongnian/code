    [TestClass]
    public class PersonSynchronizerTest {
        [TestMethod]
        public void PersonSynchronizer_GetPerson_Should_Return_Two() {
            //Arrange
            var wurAccounts = new[] { "coord001", "coord002" };
            var persons = new List<Person> {
                new Person { DisplayName = "Coordinator 1", Email="coordinator01@wur.nl", WurAccount = wurAccounts[0] },
                new Person { DisplayName = "Coordinator 2", Email="coordinator02@wur.nl", WurAccount = wurAccounts[1] }
            };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Query<Person>()).Returns(persons.AsQueryable);
            var subject = new PersonSynchronizer(mockUnitOfWork.Object);
            //Act
            var actual = subject.GetPersons(wurAccounts);
            //Assert
            actual.Should()
                .NotBeNull()
                .And.HaveCount(wurAccounts.Length);
        }
        public class PersonSynchronizer {
            private IUnitOfWork session;
            public PersonSynchronizer(IUnitOfWork session) {
                this.session = session;
            }
            public Dictionary<string, Person> GetPersons(IEnumerable<string> wurAccounts) {
                var accounts = wurAccounts.ToList();
                return this.session.Query<Person>()
                    .Where(x => accounts.Contains(x.WurAccount))
                    .ToDictionary(x => x.WurAccount);
            }
        }
        public class Person {
            public string DisplayName { get; set; }
            public string Email { get; set; }
            public string WurAccount { get; set; }
        }
        public interface IUnitOfWork {
            IQueryable<T> Query<T>();
        }
    }
    
