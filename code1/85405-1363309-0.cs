    Type t = typeof(Int64);
    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter(sb))
    {
        var expr = new CodeTypeReferenceExpression(t);
        var prov = new CSharpCodeProvider();
        prov.GenerateCodeFromExpression(expr, sw, new CodeGeneratorOptions());
    }
    // long
    Console.WriteLine(sb.ToString());
