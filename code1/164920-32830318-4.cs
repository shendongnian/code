    [TestMethod]
    public void AddMonthTest_January()
    {
        for (int i = 1; i <= 28; i++)
        {
            Assert.AreEqual(new DateTime(2015, 2, i), NextMonth(new DateTime(2015, 1, i)));
        }
        Assert.AreEqual(new DateTime(2015, 2, 28), NextMonth(new DateTime(2015, 1, 29)));
        Assert.AreEqual(new DateTime(2015, 2, 28), NextMonth(new DateTime(2015, 1, 30)));
        Assert.AreEqual(new DateTime(2015, 2, 28), NextMonth(new DateTime(2015, 1, 31)));
    }
    
    [TestMethod]
    public void AddMonthTest_February()
    {
        Assert.AreEqual(new DateTime(2015, 3, 31), NextMonth(new DateTime(2015, 2, 28)));
                
        for (int i = 1; i <= 27; i++)
        {
            Assert.AreEqual(new DateTime(2015, 3, i), NextMonth(new DateTime(2015, 2, i)));
        }            
    }
    
    [TestMethod]
    public void AddMonthTest_March()
    {
        Assert.AreEqual(new DateTime(2015, 4, 30), NextMonth(new DateTime(2015, 3, 31)));
    
        for (int i = 1; i <= 30; i++)
        {
            Assert.AreEqual(new DateTime(2015, 4, i), NextMonth(new DateTime(2015, 3, i)));
        }
    }
    
    [TestMethod]
    public void AddMonthTest_December()
    {            
        for (int i = 1; i <= 31; i++)
        {
            Assert.AreEqual(new DateTime(2016, 1, i), NextMonth(new DateTime(2015, 12, i)));
        }
    }
    
    [TestMethod]
    public void AddMonthTest_January_LeapYear()
    {
        for (int i = 1; i <= 29; i++)
        {
            Assert.AreEqual(new DateTime(2016, 2, i), NextMonth(new DateTime(2016, 1, i)));
        }            
        Assert.AreEqual(new DateTime(2016, 2, 29), NextMonth(new DateTime(2016, 1, 30)));
        Assert.AreEqual(new DateTime(2016, 2, 29), NextMonth(new DateTime(2016, 1, 31)));
    }
    
    [TestMethod]
    public void AddMonthTest_February_LeapYear()
    {
        Assert.AreEqual(new DateTime(2016, 3, 31), NextMonth(new DateTime(2016, 2, 29)));
    
        for (int i = 1; i <= 28; i++)
        {
            Assert.AreEqual(new DateTime(2016, 3, i), NextMonth(new DateTime(2016, 2, i)));
        }
    }
    [TestMethod]
    public void AddHalfYearTest_January_LeapYear()
    {        
        for (int i = 1; i <= 31; i++)
        {
            Assert.AreEqual(new DateTime(2016, 7, i), new DateTime(2016, 1, i).AddMonthToEndOfMonth(6));
        }
    }
    
    [TestMethod]
    public void AddHalfYearTest_February_LeapYear()
    {
        Assert.AreEqual(new DateTime(2016, 8, 31), new DateTime(2016, 2, 29).AddMonthToEndOfMonth(6));
    
        for (int i = 1; i <= 28; i++)
        {
            Assert.AreEqual(new DateTime(2016, 8, i), new DateTime(2016, 2, i).AddMonthToEndOfMonth(6));
        }
    }
    
    [TestMethod]
    public void AddHalfYearTest_December()
    {
        Assert.AreEqual(new DateTime(2016, 6, 30), new DateTime(2015, 12, 31).AddMonthToEndOfMonth(6));
        for (int i = 1; i <= 30; i++)
        {
            Assert.AreEqual(new DateTime(2016, 6, i), new DateTime(2015, 12, i).AddMonthToEndOfMonth(6));
        }
    }
