        CodeCompileUnit unit = CreateMyUnit();
        var attribute = new CodeAttributeDeclaration(
            new CodeTypeReference(typeof(AssemblyFileVersionAttribute)));
        attribute.Arguments.Add(
            new CodeAttributeArgument(
                new CodePrimitiveExpression("1.1.1.1")));
        unit.AssemblyCustomAttributes.Add(attribute);
