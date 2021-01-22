    var a = Assembly.Load("My.Assembly");
    foreach (var t in a.GetTypes().Where(t => t.IsSubClassOf(typeof(MyType)))
    {
        // there you have it
    }
