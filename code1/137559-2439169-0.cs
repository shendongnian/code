    public static class PropertyBuilderGenerator
    {
        public static CodeTypeDeclaration GenerateBuilder(Type destType)
        {
            if (destType == null)
                throw new ArgumentNullException("destType");
            CodeTypeDeclaration builderType = new
                CodeTypeDeclaration(destType.Name + "Builder");
            builderType.TypeAttributes = TypeAttributes.Public;
            CodeTypeReference destTypeRef = new CodeTypeReference(destType);
            CodeExpression resultExpr = AddResultField(builderType, destTypeRef);
            PropertyInfo[] builderProps = destType.GetProperties(
                BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo prop in builderProps)
            {
                AddPropertyBuilder(builderType, resultExpr, prop);
            }
            AddBuildMethod(builderType, resultExpr, destTypeRef);
            return builderType;
        }
        private static void AddBuildMethod(CodeTypeDeclaration builderType,
            CodeExpression resultExpr, CodeTypeReference destTypeRef)
        {
            CodeMemberMethod method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            method.Name = "Build";
            method.ReturnType = destTypeRef;
            method.Statements.Add(new MethodReturnStatement(resultExpr));
            builderType.Members.Add(method);
        }
        private static void AddPropertyBuilder(CodeTypeDeclaration builderType,
            CodeExpression resultExpr, PropertyInfo prop)
        {
            CodeMemberMethod method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            method.Name = prop.Name;
            method.ReturnType = new CodeTypeReference(builderType.Name);
            method.Parameters.Add(new CodeParameterDeclarationExpression(prop.Type,
                "value"));
            method.Statements.Add(new CodeAssignStatement(
                new CodePropertyReferenceExpression(resultExpr, prop.Name),
                new CodeArgumentReferenceExpression("value")));
            method.Statements.Add(new MethodReturnStatement(
                new CodeThisExpression()));
            builderType.Members.Add(method);
        }
        private static CodeFieldReferenceExpression AddResultField(
            CodeTypeDeclaration builderType, CodeTypeReference destTypeRef)
        {
            const string fieldName = "_result";
            CodeMemberField resultField = new CodeMemberField(destTypeRef, fieldName);
            resultField.Attributes = MemberAttributes.Private;
            builderType.Members.Add(resultField);
            return new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), fieldName);
        }
    }
