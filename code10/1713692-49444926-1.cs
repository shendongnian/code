	foreach (var localDeclarationStatementSyntax in localDeclarations)
	{
		foreach (VariableDeclaratorSyntax variable in localDeclarationStatementSyntax.Declaration.Variables)
		{
			var stringKind = variable.Initializer.Value.Kind();
			//Replace string variables
			if (stringKind == SyntaxKind.StringLiteralExpression)
			{
				//Remove " from string
				var value = variable.Initializer.Value.ToString().Remove(0, 1);
				value = value.Remove(value.Length - 1, 1);
				var newVariable = SyntaxFactory.ParseStatement($"string {variable.Identifier.ValueText} = @\"{value + " hello"}\";").WithAdditionalAnnotations(Formatter.Annotation, Simplifier.Annotation);
				newVariable = newVariable.NormalizeWhitespace();
                // This is new, copies the trivia (indentations, comments, etc.)
				newVariable = newVariable.WithLeadingTrivia(localDeclarationStatementSyntax.GetLeadingTrivia());
				newVariable = newVariable.WithTrailingTrivia(localDeclarationStatementSyntax.GetTrailingTrivia());
				editor.ReplaceNode(variable, newVariable);
				Console.WriteLine($"Key: {variable.Identifier.Value} Value:{variable.Initializer.Value}");
			}
		}
	}
