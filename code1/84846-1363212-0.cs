    Type t = typeof(Dictionary<string, string>);
    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter(sb))
    {
        var expr = new CodeTypeReferenceExpression(t);
        var prov = new CSharpCodeProvider();
        prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
    }
    // System.Collections.Generic.Dictionary<string, string>
    Console.WriteLine(sb.ToString());
