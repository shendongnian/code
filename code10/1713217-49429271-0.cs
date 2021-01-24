    [DynamicData("AllNotificationTypes")]
    [DataTestMethod]
    public async Task TestNotification(Type type)
    {
    
    }
    
    public static Type[] AllNotificationTypes 
    	=> typeof(INotification).Assembly.GetTypes()
            .Where(t => typeof(INotification).IsAssignableFrom(t) && !t.IsAbstract)
            .ToArray();
    
