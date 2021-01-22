    public void GetParameterValue<T>(out T destination)
    {
        object paramVal = "Blah";
        destination = default(T);
        destination = Convert.ChangeType(paramVal, typeof(T).GetType());
    }
