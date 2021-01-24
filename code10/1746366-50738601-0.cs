    public List<Required> CallerProperty<T>(T source)
    {
        List<Required> result = new List<Required>();
        Type targetInfo = target.GetType();
        var propertiesToLoop = source.GetProperties();
        foreach (PropertyInfo pi in propertiesToLoop)
        {
            Required possible = pi.GetCustomAttribute<Required>();
            if(possible != null)
            {
                result.Add(possible);
                string name = pi.Name; //This is the property name of the property that has a required attribute
            }
        }
        return result;
    }
