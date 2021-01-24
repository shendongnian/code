    string DoSomething(string username, string value) {
        var dict = new Dictionary<string,string> {
            { nameof(username), username },
            { nameof(value), value },
        };
        SomeHelper.ExecuteSP("sp_somesp", dict);
    }
