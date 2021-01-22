    CustomCollection c = new CustomCollection();
    
    bool implementICollection = c.GetType().GetInterfaces()
                                .Any(x => x.IsGenericType &&
                                x.GetGenericTypeDefinition() == typeof(ICollection<>));
