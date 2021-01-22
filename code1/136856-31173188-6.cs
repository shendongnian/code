    [Test]
    public void Mocked_Now()
    {
    	DateTime now = DateTime.Now;
    	MockDateTimeProvider.SetNow(now);    //set to mock
    	Assert.AreEqual(now, DateTimeProvider.DateTime.Now);
    	Assert.AreNotEqual(now, DateTimeProvider.DateTime.UtcNow);
    }
    
    [Test]
    public void Mocked_UtcNow()
    {
    	DateTime utcNow = DateTime.UtcNow;
    	MockDateTimeProvider.SetUtcNow(utcNow);   //set to mock
    	Assert.AreEqual(utcNow, DateTimeProvider.DateTime.UtcNow);
    	Assert.AreNotEqual(utcNow, DateTimeProvider.DateTime.Now);
    }
