    public void SomeMethod<T>(T value)
    {
        Type type = typeof(T);
        if (type == typeof(int))
        {
            SomeMethod((int) (object) value); // sadly we must box it...
        }
        else if (type == typeof(float))
        {
            SomeMethod((float) (object) value);
        }
        else if (type == typeof(string))
        {
            SomeMethod((string) (object) value);
        }
        else
        {
            throw new NotSupportedException(
                "SomeMethod is not supported for objects of type " + type);
        }
    }
