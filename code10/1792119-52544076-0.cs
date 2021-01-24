            var unit = new CodeCompileUnit();
            var attr = new CodeTypeReference(typeof(AssemblyVersionAttribute));
            var decl = new CodeAttributeDeclaration(attr, new CodeAttributeArgument(new CodePrimitiveExpression("1.0.2.42")));
            unit.AssemblyCustomAttributes.Add(decl);
            var prov = new CSharpCodeProvider();
            var sw = new StringWriter();
            prov.GenerateCodeFromCompileUnit(unit, sw, new CodeGeneratorOptions());
            Console.WriteLine(sw.ToString());
            Console.ReadLine();
