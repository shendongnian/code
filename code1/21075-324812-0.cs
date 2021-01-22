    static string ToLiteral(string input)
        {
            var writer = new StringWriter();
            CSharpCodeProvider provider = new CSharpCodeProvider();
            provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
            return writer.GetStringBuilder().ToString();
        }
