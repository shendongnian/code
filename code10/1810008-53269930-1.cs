    public ICar CreateCar(string brand, string spec)
    {
        System.Type type = typeof( ICar ).Assembly.GetTypes().Where( t => t.Name == brand ).FirstOrDefault();
        object instance = Activator.CreateInstance( type, new object[ 1 ] { specs } );
        return (ICar)instance;
    }
