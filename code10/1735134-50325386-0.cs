    public IDictionary<string, IDictionary<string, string>> GetConstants() =>
        typeof(SecondClass).GetNestedTypes()
            .ToDictionary(
                type => type.Name,
                (IDictionary<string, string>) 
                type.GetFields().ToDictionary(f => f.Name, (string) f => f.GetValue(null)));
