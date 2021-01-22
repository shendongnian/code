    public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
    {
        Type type1 = entry.DeclaringType;
        PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
        CodeExpression[] expressionArray1 = new CodeExpression[1];
        expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
      
        return new CodeCastExpression(
            descriptor1.PropertyType,
            new CodeMethodInvokeExpression(
                new CodeThisReferenceExpression(),
                "GetData",
                expressionArray1));
    }
