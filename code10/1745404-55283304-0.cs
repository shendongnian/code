    /// <summary>
    /// Tests the account controller.
    /// </summary>
    [TestMethod]
    public void TestAccountController()
    {
        // arrange
        // act
        var result = CheckCorrectUsageOfAttributes.ForController<AccountController>();
        // assert
        var first = result.FirstOrDefault();
        Assert.IsNull(first, first);
    }
