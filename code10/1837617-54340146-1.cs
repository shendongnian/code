    var bindingSources = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic |
        System.Reflection.BindingFlags.Public |
        System.Reflection.BindingFlags.Instance)
        .Where(x => typeof(BindingSource).IsAssignableFrom(x.FieldType))
        .ToDictionary(x => x.Name, x => (BindingSource)x.GetValue(this));
