    public IReadOnlyDictionary<string, IDictionary<string, string>> GetConstants() =>
        typeof(SecondClass).GetNestedTypes()
            .ToDictionary(
                type => type.Name,
                (IReadOnlyDictionary<string, string>) 
                type.GetFields().ToDictionary(f => f.Name, (string) f => f.GetValue(null)));
