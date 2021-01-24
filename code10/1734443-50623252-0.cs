            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace samples = new CodeNamespace("ClassLibrary1");
            compileUnit.Namespaces.Add(samples);
            samples.Imports.Add(new CodeNamespaceImport("System"));
            samples.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            samples.Imports.Add(new CodeNamespaceImport("System.Text"));
            CodeTypeDeclaration _class = new CodeTypeDeclaration("TestClass");
            CodeMemberField _field = new CodeMemberField();
            _field.Attributes = MemberAttributes.Private;
            _field.Name = "_testMember";
            _field.Type = new CodeTypeReference(typeof(List<string>));
            var initialiseExpression = new CodeArrayCreateExpression(
                new CodeTypeReference(typeof(string)),
                new CodePrimitiveExpression("A"),
                new CodePrimitiveExpression("B"),
                new CodePrimitiveExpression("C"));
            _field.InitExpression = new CodeObjectCreateExpression(new CodeTypeReference(typeof(List<string>)), initialiseExpression);
            _class.Members.Add(_field);
