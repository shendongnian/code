	InterpolatedStringExpressionSyntax interpolatedExpression = // you received it before
    // as you know that your member is the first contet of InterpolatedStringExpressionSyntax 
    var symbolInfo = semanticModel.GetSymbolInfo(((interpolatedExpression).Contents[0] as InterpolationSyntax).Expression);
	if (!(symbolInfo.Symbol is null))
	{
        // assume that exists only a one declaration
		var fieldDeclaration = symbolInfo.Symbol.DeclaringSyntaxReferences[0].GetSyntax() as VariableDeclaratorSyntax;
		if (!(fieldDeclaration is null))
		{
            // retrieves text from `SomeValue = "some value"`
			var text = (fieldDeclaration.Initializer.Value as LiteralExpressionSyntax)?.Token.Text;
		}
	}
