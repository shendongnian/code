    public override bool CanConvert(Type objectType) {
        //Check of any JsonPropertyAttribute has nested property name
        return objectType
            .GetProperties()
            .Any(p => 
                p.CanRead 
                && p.CanWrite
                && p.GetCustomAttributes(true)
                    .OfType<JsonPropertyAttribute>()
                    .Count(jp => (jp.PropertyName ?? p.Name).Contains('.')) > 0);
    }
    
    
