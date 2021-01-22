    CodeDomProvider csharpProvider = CodeDomProvider.CreateProvider("C#");
    CodeTypeReference typeReference = new CodeTypeReference(typeof(Dictionary<string, int>));
    CodeVariableDeclarationStatement variableDeclaration = new CodeVariableDeclarationStatement(typeReference, "dummy");
    StringBuilder sb = new StringBuilder();
    using (StringWriter writer = new StringWriter(sb))
    {
        csharpProvider.GenerateCodeFromStatement(variableDeclaration, writer, new CodeGeneratorOptions());
    }
    sb.Replace(" dummy;", null);
    Console.WriteLine(sb.ToString());
