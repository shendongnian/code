    statements.Add(new CodeVariableDeclarationStatement("SomeRefType", "typedVal"));
    statements.Add(new CodeConditionStatement(
        new CodeMethodInvokeExpression(new CodeTypeOfExpression("SomeRefType"), "IsInstanceOfType", new CodeVariableReferenceExpression("obj")),
        new CodeStatement[] { 
            new CodeAssignStatement(new CodeVariableReferenceExpression("typedVal"), new CodeCastExpression("SomeRefType", new CodeVariableReferenceExpression("obj")))
        },
        new CodeStatement[] {
            new CodeAssignStatement(new CodeVariableReferenceExpression("typedVal"), new CodePrimitiveExpression(null))
        }));
    // SomeRefType typedVal = typeof(SomeRefType).IsInstanceOfType(obj) ? (SomeRefType)obj : null;
