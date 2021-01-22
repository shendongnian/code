    static void Main(string[] args)
    {
        var users = GetUserGroup();
        var rows = users.SelectMany(x => x.UserPreferences.Select(y => new { x.FirstName, x.LastName, y.Name, y.UserValue }));
        var userProperties = rows.Select(x => x.Name).Distinct();
        foreach (var property in userProperties)
        {
            Console.WriteLine(property);
        }
        Console.WriteLine();
    
        // The hard-coded variety.
        var results = users.Select(x => new
        {
            x.FirstName,
            x.LastName,
            FavoriteColor = x.UserPreferences.Where(y => y.Name == "Favorite color").Select(y => y.UserValue).FirstOrDefault(),
            FavoriteAnimal = x.UserPreferences.Where(y => y.Name == "Favorite mammal").Select(y => y.UserValue).FirstOrDefault(),
        });
    
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // The dynamic variety.
        DynamicProperty[] dynamicProperties = new DynamicProperty[2 + userProperties.Count()];
        dynamicProperties[0] = new DynamicProperty("FirstName", typeof(string));
        dynamicProperties[1] = new DynamicProperty("LastName", typeof(string));
        int propIndex = 2;
        foreach (var property in userProperties)
        {
            dynamicProperties[propIndex++] = new DynamicProperty(property, typeof(string));
        }
        Type resultType = ClassFactory.Instance.GetDynamicClass(dynamicProperties);
        ConstructorInfo constructor = resultType.GetConstructor(new Type[] {});
        object[] constructorParams = new object[] { };
        PropertyInfo[] propInfoList = resultType.GetProperties();
        PropertyInfo[] constantProps = propInfoList.Where(x => x.Name == "FirstName" || x.Name == "LastName").OrderBy(x => x.Name).ToArray();
        IEnumerable<PropertyInfo> dynamicProps = propInfoList.Where(x => !constantProps.Contains(x));
        // The actual dynamic results creation.
        var dynamicResults = users.Select(user =>
        {
            object resultObject = constructor.Invoke(constructorParams);
            constantProps[0].SetValue(resultObject, user.FirstName, null);
            constantProps[1].SetValue(resultObject, user.LastName, null);
            foreach (PropertyInfo propInfo in dynamicProps)
            {
                var val = user.UserPreferences.FirstOrDefault(x => x.Name == propInfo.Name);
                if (val != null)
                {
                    propInfo.SetValue(resultObject, val.UserValue, null);
                }
            }
            return resultObject;
        });
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
    
        // Display the results.
        var displayResults = dynamicResults;
        //var displayResults = results;
    
        if (displayResults.FirstOrDefault() != null)
        {
            PropertyInfo[] properties = displayResults.First().GetType().GetProperties();
            int columnWidth = Console.WindowWidth / properties.Length;
    
            int index = 0;
            foreach (PropertyInfo property in properties)
            {
                Console.SetCursorPosition(index++ * columnWidth, Console.CursorTop);
                Console.Write(property.Name);
            }
            Console.WriteLine();
    
            foreach (var result in displayResults)
            {
                index = 0;
                foreach (PropertyInfo property in properties)
                {
                    Console.SetCursorPosition(index++ * columnWidth, Console.CursorTop);
                    Console.Write(property.GetValue(result, null) ?? "(null)");
                }
                Console.WriteLine();
            }
        }
    
        Console.WriteLine("\r\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static List<User> GetUserGroup()
    {
        List<User> users = new List<User>();
    
        User user1 = new User();
        user1.FirstName = "John";
        user1.LastName = "Doe";
        user1.UserPreferences = new List<UserPreference>();
    
        user1.UserPreferences.Add(new UserPreference("Favorite color", "Red"));
        user1.UserPreferences.Add(new UserPreference("Birthday", "Friday"));
    
        User user2 = new User();
        user2.FirstName = "Jane";
        user2.LastName = "Doe";
        user2.UserPreferences = new List<UserPreference>();
    
        user2.UserPreferences.Add(new UserPreference("Favorite mammal", "Dolphin"));
        user2.UserPreferences.Add(new UserPreference("Favorite color", "Blue"));
    
        users.Add(user1);
        users.Add(user2);
    
        return users;
    }
