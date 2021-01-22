    var obj = // instance of SomeClass...
    var t = typeof(SomeClass); // you need the type object
    var member = t.GetField("TextEvent"); 
    var oldEvent = member.GetValue(obj) as Delegate; 
    var newEvent = Delegate.Combine(oldEvent, new Action<string>(delegate(string s)){});
    member.SetValue(obj, newEvent); // done!
