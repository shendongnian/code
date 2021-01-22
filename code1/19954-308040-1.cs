    object x = GetObjectFromSomewhere();
    // I want to create a List<?> containing the existing
    // object, but strongly typed to the "right" type depending
    // on the type of the value of x
    MethodInfo method = GetType().GetMethod("BuildListHelper");
    method = method.MakeGenericMethod(new Type[] { x.GetType() });
    object list = method.Invoke(this, new object[] { x });
    // Later
    public IList<T> BuildListHelper<T>(T item)
    {
        List<T> list = new List<T>();
        list.Add(item);
        return list;
    }
