    var fields = typeof(MyStaticClass).GetFields(BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Public);
    foreach (var field in fields)
    {
        var type = field.GetType();
        field.SetValue(null, null);
    }
    Init(); // if there are values to be initialized
