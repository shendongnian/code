in MemoryRepositoryUserTest...
[Test]
GetById_RecordFound() {
    MemoryRepositoryUser repository = new MemoryRepositoryUser();
    User expected = User with ID 762 and the mandatory properties set
    repository.Add(expected);
    User actual = repository.GetById(762);
    Assert.AreEquals(expected, actual);
}
