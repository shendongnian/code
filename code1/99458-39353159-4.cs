    public void TestBigUnicode() {
        var s = "\U00020000";
        var encoded = s.EncodeNonAsciiCharacters();
        var decoded = encoded.DecodeEncodedNonAsciiCharacters();
        Assert.Equals(s, decoded);
    }
