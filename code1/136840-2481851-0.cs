    [Test]  
    public void TestOfDateTime()  
    {  
        MDateTime.NowGet = () => new DateTime(2000,1,1);
     
        var result = new UnderTest().CalculateSomethingBasedOnDate();  
    }
