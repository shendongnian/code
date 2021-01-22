    [Test]
    public void EncryptDecryptTest()
    {
        var instance = new WebConfigEncryption();
        var encrypted = instance.Encrypt("123");
        Assert.That(encrypted, Is.EqualTo("AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAevf7SJH9cEKkBiHCivE4JQQAAAACAAAAAAADZgAAwAAAABAAAAASjwJ8+/Nmg3pNK/Wqo86nAAAAAASAAACgAAAAEAAAAJRmANqMKFWtP+Oa6o2OTzUIAAAAn1z15Bhbpv0UAAAALM1ePWu+BVczkUCzbhBIY9bOPLo="));
        var decrypted = instance.Decrypt(encrypted);
        Assert.That(decrypted, Is.EqualTo("123"));
    }
