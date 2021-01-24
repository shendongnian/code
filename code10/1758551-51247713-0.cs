    [TestMethod]
    public void CheckMyData()
    {
        var _info = GenerateData();
        Assert.IsTrue(_info.Include == true); //Mock condition to fulfill.
        Assert.IsFalse(_info.InfoName.Contains("test1_Name"));
        //... and so on...
        //You can also check for the expected type of values.
    }
    private Info GenerateData()
    {
        var data = new Info
            {
              //We set some mokup values here
              Include = true,
              InfoName = "test_NAME",
              StartDate = "12-12-2005",
              EndDate = "14/12/2005",
              Mark = 12
            }
        return data;
    }
