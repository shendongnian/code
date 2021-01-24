    List<Type> letterTypes = typeof(LetterBase).Assembly.GetTypes()
        .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(LetterBase)))
        .ToList();
    foreach(Type letterType in letterTypes)
    {
        LetterTypeAttribute attribute = type.GetCustomAttributes<LetterTypeAttribute>()
                                            .First();
        
        builder.RegisterType(letterType)
               .Keyed<LetterBase>(attribute.LetterId);
    }
