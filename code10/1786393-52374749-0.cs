    string Imports(Class c)
    {
        var props = c.Properties.Where(p => !p.Attributes.Any(a => String.Equals(a.name, "TypeScriptIgnore", StringComparison.OrdinalIgnoreCase)));
    
        IEnumerable<Type> types = props
            .Select(p => p.Type)
            .SelectMany(t => t.IsGeneric ? t.TypeArguments : new[] { t } as IEnumerable<Type>)
            .Where(t => !t.IsPrimitive || t.IsEnum)
            .Where(t => !t.Attributes.Any(a => String.Equals(a.name, "TypeScriptIgnore", StringComparison.OrdinalIgnoreCase)))
            .Distinct();
    
        return string.Join(Environment.NewLine, types.Select(t => $"import {{ {t.Name} }} from './{t.Name}';").Distinct());
    }
