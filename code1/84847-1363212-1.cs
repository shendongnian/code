    var type = typeof(Dictionary<string, string>);
    Console.WriteLine(TypeToString(type));
    // ...
    public static string TypeToString(Type type)
    {
        if (type == null) throw new ArgumentNullException("type");
        var sb = new StringBuilder();
        using (var sw = new StringWriter(sb))
        {
            var expr = new CodeTypeReferenceExpression(type);
            var prov = new CSharpCodeProvider();
            prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
        }
        return sb.ToString();
    }
