    [TestMethod]
    [ExpectedException(typeof(DataAccessException))]
    public void ATestMethod() {
      ...
      NHibernateRepositoryBaseDeleteHelper(itemValue, keyValue);
    }
