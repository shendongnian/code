    public string Ebnf
    {
    get {
        var props = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        string[] ebnfs = props
          .Where(prop => prop.PropertyType.IsSubclassOf(typeof(ARule)))
          .Select(prop => (ARule)prop.GetValue(this, null))
          .Select(rule => rule.Name + " = " + rule.Ebnf + ".")
          .ToArray();
        return string.Join("\n", ebnfs);
    }
    }
