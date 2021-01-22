    public class foo
    {
    }
    
    public class bar : foo
    {
    }
    
    bar myBar = new bar();
    
    // Would fail, even though bar is a child of foo.
    if (myBar.getType == typeof(foo))
    
    // However this Would work
    if (myBar is foo)
