    var explicitProperties =
        from prop in typeof(TempClass).GetProperties(
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
        let getAccessor = prop.GetGetMethod(true)
        where getAccessor.IsFinal && getAccessor.IsPrivate
        select prop;
    foreach (var p in explicitProperties)
        Console.WriteLine(p.Name);
