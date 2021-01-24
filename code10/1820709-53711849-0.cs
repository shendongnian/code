    [TestMethod]
    public void AllMethodProperlyReturnsAllInstances()
    {
        // Arrange
        Model.PopulateDatabaseConnection(GlobalTestData.TestingDirectory);
        List<Universe> universes = new List<Universe>();
        universes.Add(new Universe() { Name = "Test1" });
        universes.Add(new Universe() { Name = "Test2" });
        universes.Add(new Universe() { Name = "Test3" });
        // Act
        universes.ForEach(x => x.Save()); // <-- Break Point Here
        List<Universe> returnUniverses = Universe.All();
        // Assert
        foreach (Universe universe in universes)
        {
            if (!returnUniverses.Any(x => x.ID == universe.ID)) { Assert.Fail(); }
        }
    }
