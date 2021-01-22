    var a = Assembly.Load("My.Assembly");
    foreach (var t in a.GetTypes().Where(t => t is IMyInterface))
    {
        // there you have it
    }
