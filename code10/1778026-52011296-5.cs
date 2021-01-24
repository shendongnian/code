    public IEnumerable<Phrase> GetPhrases(string language)
    {
        // assuming the language parameter is "english" or "spanish"
        var theType = $"YourNamespace.{language}Phrase";
        //assuming your models are in the current assembly
        Type type = TypeInfo.GetType(theType, true, true);
    
        MethodInfo method = typeof(Queryable).GetMethod("OfType").MakeGenericMethod(type);
        var obj = appContext.Phrases.AsQueryable();
        var result = method.Invoke(obj, new[] { obj });
        return result as IEnumerable<Phrase>;
    }
