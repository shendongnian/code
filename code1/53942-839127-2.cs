    var setterCount = (from s in typeof(string).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.GetSetMethod())
        where s != null && s.IsPublic
        select s).Count();
    
    Assert.That(setterCount == 0, Is.True, "Immutable rule is broken");
