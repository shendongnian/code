    public static object Get<Person, TProperty>(Person person, Func<Person, TProperty> func)
    {
        object result = null;
        if (person != null)
        {
            result = func.Invoke(person);
        }
        return result;
    }
