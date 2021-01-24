    public Dictionary<string, myCustomType> AvailableTeams; //color, team
    public void InitializeTeams()
    {
        AvailableTeams = new Dictionary<string, myCustomType>()
        {
            ["Yellow"] = new myCustomType("Yellow"),
            ["Red"] = new myCustomType("Red"),
            ["Blue"] = new myCustomType("Blue"),
            ["Green"] = new myCustomType("Green")
        };
    }
