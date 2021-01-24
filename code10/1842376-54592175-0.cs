     CodeConstructor constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            
        foreach (var item in features)
            {
                CodeFieldReferenceExpression reference =
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), item.Id);
                constructor.Statements.Add(new CodeAssignStatement(reference, new CodePrimitiveExpression(item.TestCase)));
            }
            targetClass.Members.Add(constructor);
