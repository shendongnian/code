    // Create a helper method to create the expression
    public static Expression<Func<TEntity, bool>> MakeExpression<TEntity>()
    {
        // your custom expression here
        return x => true;
    }
    // Declare your action as a generic method
    public static void MyAction<TEntity>(TEntity input)
    {
        // your action here
    }
    // Then you can use it like this:
    var func = typeof(Example).GetMethod("MakeExpression", BindingFlags.Public | BindingFlags.Instance).MakeGenericMethod(classType).Invoke(example, new object[0]);
    var action = typeof(Example).GetMethod("MyAction", BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(classType ).CreateDelegate(typeof(Action<>).MakeGenericType(classType));
    genericMInfo.Invoke(example, new object[] { func, action });
