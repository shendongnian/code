    // ...
    else if (p.ParameterType == typeof(System.DateTime))
    {
        DateTime dt = DATETIME();
        var ticks = new CodePrimitiveExpression(dt.Ticks);
        var kind = new CodeFieldReferenceExpression
            (
                new CodeTypeReferenceExpression("System.DateTimeKind"),
                dt.Kind.ToString()
            );
        return new CodeVariableDeclarationStatement
            (
                p.ParameterType,
                options.sVariableNamePrix + p.Name,
                new CodeObjectCreateExpression("System.DateTime", ticks, kind)
            );
    }
