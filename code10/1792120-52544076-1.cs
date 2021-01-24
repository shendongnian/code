            ...
            var unit = new CodeCompileUnit();
            var attr = new CodeTypeReference(typeof(AssemblyVersionAttribute));
            var decl = new CodeAttributeDeclaration(attr, new CodeAttributeArgument(new CodePrimitiveExpression("1.0.2.42")));
            unit.AssemblyCustomAttributes.Add(decl);
            var prov = new CSharpCodeProvider(ProviderOptions);
            var assemblyInfo = new StringWriter();
            prov.GenerateCodeFromCompileUnit(unit, assemblyInfo, new CodeGeneratorOptions());
            var result = prov.CompileAssemblyFromSource(CParams, new[] {"public class p{public static void Main(){}}", assemblyInfo.ToString()});
