    public static Action<TEntity> MakeAction<TEntity>()
    {
        // your custom action here.
        return e => { };
    }
    // Then:
    var action = typeof(Example).GetMethod("MakeAction", BindingFlags.Public | BindingFlags.Instance).MakeGenericMethod(classType).Invoke(example, new object[0]);
