    public User(dynamic jObject)
    {
        FirstName = GetValue(() => jObject.first_name);
        LastName = GetValue(() => jObject.last_name);
        Bithday = GetValue(() => jObject.bdate);
        Sex = GetValue(() => jObject.sex);
    }
    private static string GetValue(GetValueDelegate getValueMethod)
    {
        try
        {
            return getValueMethod();
        }
        catch
        {
            return null;
        }
    }
    private delegate string GetValueDelegate();
