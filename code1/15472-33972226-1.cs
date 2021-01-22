    [TestMethod()]
    public void Event_UserName_PropertyChangedWillBeFired()
    {
        var user = new User();
        AssertPropertyChanged(user, (x) => x.UserName = "Bob", "UserName");
    }
