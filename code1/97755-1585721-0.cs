    public static void IncludeProperties(Expression<Action<IUser>> selectedProperties)
    {
        // some logic to store parameter   
    }
    
    public static void S(params object[] props)
    {
        // dummy method to get to the params syntax
    }
    
    [Test]
    public void ParamsTest()
    {
        IncludeProperties(u => S(
            u.Id,
            u.Name
            ));
    
    }
