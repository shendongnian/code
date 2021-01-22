    [Test]
    public void GetReasonDescriptionTest()
    {
        string reasonDescription = GetReasonDescription(3050);
        Assert.That(reasonDescription, Is.EqualTo("GHI_REASONCODE_DESCRIPTION007"));
    }
