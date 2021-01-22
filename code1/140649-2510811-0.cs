    [Test]
    public void Getting_whole_number()
    {
       Assert.AreEqual("5", Math.Truncate(5.5).ToString());
       Assert.AreEqual("5", ((int)5.5).ToString());
    }
