    static bool AreTwoEqual(Component inApp, Component inDb)
    {
        string[] propertiesToExclude = new string[] { "DateCreated", "Id" };
        PropertyInfo[] propertyInfos = typeof(Component).GetProperties()
                                                 .Where(x => !propertiesToExclude.Contains(x.Name))
                                                 .ToArray();
        
        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            bool areSame = inApp.GetType().GetProperty(propertyInfo.Name).GetValue(inApp, null).Equals(inDb.GetType().GetProperty(propertyInfo.Name).GetValue(inDb, null));
            if (!areSame)
            {
                return false;
            }
        }
        return true;
    }
