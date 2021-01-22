    [Test]
    public void Example()
    {
        int num = (int)double.Parse("6.21129e+006");
    
        Assert.That(num, Is.EqualTo(6211290));
    }
