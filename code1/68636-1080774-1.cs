    [Test]
    public void Create_Person_Calls_Add_On_Repository () {
        Mock<IPersonRepository> mockRepository = new Mock<IPersonRepository>();
        PersonManager manager = new PersonManager(mockRepository.Object);
        manager.CreatePerson("Bob", 12);
        mockRepository.Verify(pr => pr.Add(It.Is<Person>(p => p.Age == 12)));
    }
