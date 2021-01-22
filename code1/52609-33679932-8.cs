    [TestMethod]
    public void DecryptSecureStringWithAction()
    {
        // Arrange
        var secureString = new SecureString();
        foreach (var c in "UserPassword123".ToCharArray())
            secureString.AppendChar(c);
        secureString.MakeReadOnly();
        // Act
        string copyPassword = null;
        Strings.DecryptSecureString(secureString, (password) =>
        {
            copyPassword = password; // Please don't do this!
        });
        // Assert
        Assert.IsNull(copyPassword); // Fails
    }
