    [TestMethod]
    public void can_get_open_generic_interface_off_of_implementor()
    {
        Type[] typeParams = typeof(OpenGenericWithOpenService<>).GetGenericArguments();
        Type constructed = typeof(IGenericService<>).MakeGenericType(typeParams);
        typeof(OpenGenericWithOpenService<>).GetInterfaces().First()            
            .ShouldEqual(constructed);
    }
