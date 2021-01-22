    VBCodeProvider vbProvider = new VBCodeProvider();
    CSharpCodeProvider csProvider = new CSharpCodeProvider();
    var errorMessagePart1 = new CodePrimitiveExpression("Unhandled Error in Silverlight Application \"");
    var errorMessagePart2 = new CodeVariableReferenceExpression("errorMsg");
    var errorMessagePart3 = new CodePrimitiveExpression("\"");
    var errorMessage = new CodeBinaryOperatorExpression(new CodeBinaryOperatorExpression(errorMessagePart1, CodeBinaryOperatorType.Add, errorMessagePart2), CodeBinaryOperatorType.Add, errorMessagePart3);
    var expression = new CodeThrowExceptionStatement(new CodeObjectCreateExpression("Error", errorMessage));
        
    StringWriter writer = new StringWriter();
    vbProvider.GenerateCodeFromStatement(expression, writer, new CodeGeneratorOptions());
    string vb = writer.ToString();
    writer = new StringWriter();
    csProvider.GenerateCodeFromStatement(expression, writer, new CodeGeneratorOptions());
    string cs = writer.ToString();
    Console.WriteLine(vb);
    Console.WriteLine(cs);
