    [Test]
    public void ItShouldMarkCorrespondingSettingsAsDeleted()
    {
        var setting1 = new Setting(guid1);
        var setting2 = new Setting(guid2);
        var settings = new Settings(new[] { setting1, setting2 });
    
        settings.DeleteAllSettingsLinkedToSoftware(guid1);
    
        Assert.That(setting1.IsDeleted, Is.True);
        Assert.That(setting1.IsDeleted, Is.False);
    }
