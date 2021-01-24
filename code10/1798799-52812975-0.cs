    var values = Bp.GetType()
        .GetProperties(BindingFlags.DeclaredOnly |
            BindingFlags.Public |
            BindingFlags.Instance)
        .Select(x =>
        new
            {
                property = x.Name,
                value = x.GetValue(Bp, null)
            }).ToDictionary(x => x.property, y => y.value.ToString());
