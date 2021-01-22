    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
    using Microsoft.CSharp;
    namespace WpfApplication1
    {
    public class DependencyPropertyGenerator
    {
        public static Type Generate(Dictionary<string, Type> typeDef)
        {
            var codeCompileUnit = new CodeCompileUnit();
            var codeNamespace = new CodeNamespace("Generated");
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Windows"));
            var codeTypeDeclaration = new CodeTypeDeclaration("DataObject")
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed
            };
            codeTypeDeclaration.BaseTypes.Add(new CodeTypeReference(typeof (DependencyObject)));
            codeNamespace.Types.Add(codeTypeDeclaration);
            codeCompileUnit.Namespaces.Add(codeNamespace);
            AddProperties(codeTypeDeclaration, typeDef);
            return CompileAssembly(codeCompileUnit);
        }
        public static void AddProperties(CodeTypeDeclaration targetClass, Dictionary<string, Type> typeDef)
        {
            foreach (var pair in typeDef)
            {
                var dpProperty = new CodeMemberField
                {
                    Name = pair.Key + "Property",
                    Attributes = MemberAttributes.Public | MemberAttributes.Static,
                    Type = new CodeTypeReference("DependencyProperty"),
                    InitExpression = new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression("DependencyProperty"),
                        "Register",
                        new CodePrimitiveExpression(pair.Key),
                        new CodeTypeOfExpression(pair.Value),
                        new CodeTypeOfExpression(targetClass.Name),
                        new CodeObjectCreateExpression(typeof (PropertyMetadata),
                            new CodeDefaultValueExpression(new CodeTypeReference(pair.Value))))
                };
                targetClass.Members.Add(dpProperty);
                var clrProperty = new CodeMemberProperty
                {
                    Name = pair.Key,
                    Type = new CodeTypeReference(pair.Value),
                    Attributes = MemberAttributes.Public | MemberAttributes.Final
                };
                clrProperty.GetStatements.Add(
                    new CodeMethodReturnStatement(new CodeCastExpression(pair.Value,
                        new CodeMethodInvokeExpression(null, "GetValue",
                            new CodeFieldReferenceExpression(null, dpProperty.Name)))
                        ));
                clrProperty.SetStatements.Add(
                    new CodeMethodInvokeExpression(null, "SetValue",
                        new CodeFieldReferenceExpression(null, dpProperty.Name),
                        new CodePropertySetValueReferenceExpression()));
                targetClass.Members.Add(clrProperty);
            }
        }
        private static Type CompileAssembly(CodeCompileUnit compileUnit)
        {
            var compilerParameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            var executingAssembly = Assembly.GetExecutingAssembly();
            compilerParameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (var assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                compilerParameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }
            using (var provider = new CSharpCodeProvider())
            {
                var compileResults = provider.CompileAssemblyFromDom(compilerParameters, compileUnit);
                var compiledAssembly = compileResults.CompiledAssembly;
                return compileResults.Errors.Count > 0 ? null : compiledAssembly.GetType("Generated.DataObject");
            }
        }
    }
    }
