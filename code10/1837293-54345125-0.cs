    void Analyze(SyntaxNodeAnalysisContext context)
    {
        var node = context.Node as SimpleNameSyntax;
        // we're only interested in delegates
        var type = context.SemanticModel.GetTypeInfo(node, context.CancellationToken).ConvertedType;
        if (type == null || type.TypeKind != TypeKind.Delegate)
        {
            return;
        }
        // we're only interested in methods from the current assembly
        var symbol = context.SemanticModel.GetSymbolInfo(node, context.CancellationToken).Symbol;
        if (symbol == null ||
            symbol.Kind != SymbolKind.Method ||
            !symbol.ContainingAssembly.Equals(context.SemanticModel.Compilation.Assembly))
        {
            return;
        }
        // now you know symbol is a method in the same assembly, that is converted to a delegate
    }
