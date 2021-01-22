    [Test]
    public void EncryptDecryptTest()
    {
        var instance = new WebConfigEncryption();
        var encrypted = instance.Encrypt("123");
        var decrypted = instance.Decrypt(encrypted);
        Assert.That(decrypted, Is.EqualTo("123"));
    }
