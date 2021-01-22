    [TestMethod]
    public void GetVenueTest()
    {
        // CreateTestEntities() is a helper that initializes my entity framework DbContext
        // with the correct connection string for the testing database.
        using (var entityFrameworkContext = CreateTestEntities())
        {
            // Do whatever testing you want here:
            bool result = entityFrameworkContext.TestSomething()
            Assert.IsTrue(result);
        }
    }
