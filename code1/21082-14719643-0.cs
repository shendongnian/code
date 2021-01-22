    private static string ToLiteral(string input)
    {
        using (var writer = new StringWriter())
        {
            using (var provider = CodeDomProvider.CreateProvider("CSharp"))
            {
                provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, new CodeGeneratorOptions {IndentString = "\t"});
                var literal = writer.ToString();
                literal = literal.Replace(string.Format("\" +{0}\t\"", Environment.NewLine), "");
                return literal;
            }
        }
    }
