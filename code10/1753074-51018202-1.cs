    Type contextFactoryType = 
        Type.GetType("Media.DB.Context.Implementation." + Settings.ContextFactory);
    ConstructorInfo ci = contextFactoryType .GetConstructor(
        BindingFlags.Instance | BindingFlags.NonPublic,
        binder: null, new Type[] { typeof(string) }, modifiers: null);
    object[] args = new object[] { connString };
    var instance = (BaseContext<DbContext> instance)ci.Invoke(args);
    return instance;
