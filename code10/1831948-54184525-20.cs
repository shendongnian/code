    public override bool CanConvert(Type objectType) {
         //Check if any JsonPropertyAttribute has a nested property name {name}.{sub}
        return objectType
            .GetProperties()
            .Any(p => 
                p.CanRead 
                && p.CanWrite
                && p.GetCustomAttributes(true)
                    .OfType<JsonPropertyAttribute>()
                    .Any(jp => (jp.PropertyName ?? p.Name).Contains('.'))
            );
    }
