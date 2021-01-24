    private Dictionary<string,SomeType> usersResult= new Dictionary<string,SomeType>();
    [Given(@"""(.*)"" is created a record")]
    public void GivenIsCreatedARecord(string username)
    {
        var recordRef=<<some Logic >>;
        usersResult.add(username,recordRef);
        //other stuff
    }
