    public override void Initialize(AnalysisContext context)
    {
        context.RegisterSyntaxNodeAction(AnalyzerInvocation, SyntaxKind.InvocationExpression);
    }
    private static void AnalyzerInvocation(SyntaxNodeAnalysisContext context)
    {
        var invocation = (InvocationExpressionSyntax)context.Node;
        var methodDeclaration = (context.SemanticModel.GetSymbolInfo(invocation, context.CancellationToken).Symbol as IMethodSymbol);
        //There are several reason why this may be null e.g invoking a delegate
        if (null == methodDeclaration)
        {
            return;
        }
        var methodAttributes = methodDeclaration.GetAttributes();
        var attributeData = methodAttributes.FirstOrDefault(attr => IsIDEMessageAttribute(context.SemanticModel, attr, typeof(IDEMessageAttribute)));
        if(null == attributeData)
        {
            return;
        }
        var message = GetMessage(attributeData); 
        var diagnostic = Diagnostic.Create(Rule, invocation.GetLocation(), methodDeclaration.Name, message);
        context.ReportDiagnostic(diagnostic);
    }
    static bool IsIDEMessageAttribute(SemanticModel semanticModel, AttributeData attribute, Type desiredAttributeType)
    {
        var desiredTypeNamedSymbol = semanticModel.Compilation.GetTypeByMetadataName(desiredAttributeType.FullName);
        var result = attribute.AttributeClass.Equals(desiredTypeNamedSymbol);
        return result;
    }
    static string GetMessage(AttributeData attribute)
    {
        if (attribute.ConstructorArguments.Length < 1)
        {
            return "This method is obsolete";
        }
        return (attribute.ConstructorArguments[0].Value as string);
    }
