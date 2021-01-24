    var test = "12345";
    
    var thing = new Dictionary<string, Delegate>();
    thing.Add("key", new Action( () => IsNumeric.Test(test)));
    thing.Add("key", new Action( () => Length.Test(test, 5)));
