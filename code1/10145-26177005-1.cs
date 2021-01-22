    [Test]
    public void EncryptDecrypt()
    {
        // Arrange
        var subject = new StringEncryption();
        var originalString = "Testing123!£$";
        // Act
        var encryptedString1 = subject.Encrypt(originalString);
        var encryptedString2 = subject.Encrypt(originalString);
        var decryptedString1 = subject.Decrypt(encryptedString1);
        var decryptedString2 = subject.Decrypt(encryptedString2);
        // Assert
        Assert.AreEqual(originalString, decryptedString1, "Decrypted string should match original string");
        Assert.AreEqual(originalString, decryptedString2, "Decrypted string should match original string");
        Assert.AreNotEqual(originalString, encryptedString1, "Encrypted string should not match original string");
        Assert.AreNotEqual(encryptedString1, encryptedString2, "String should never be encrypted the same twice");
    }
