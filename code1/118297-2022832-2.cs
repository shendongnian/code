    namespace DynamicCompilation
    {
        using System;
        using System.CodeDom;
        using System.CodeDom.Compiler;
        using System.Reflection;
    
        using Microsoft.CSharp;
    
        internal static class Program
        {
            private static void Main()
            {
                var ccu = new CodeCompileUnit();
                var cns = new CodeNamespace("Aesop.Demo");
    
                cns.Imports.Add(new CodeNamespaceImport("System"));
    
                var ctd = new CodeTypeDeclaration("Test")
                {
                    TypeAttributes = TypeAttributes.Public
                };
                var ctre = new CodeTypeReferenceExpression("Console");
                var cmie = new CodeMethodInvokeExpression(ctre, "WriteLine", new CodePrimitiveExpression("Hello World!"));
                var cmm = new CodeMemberMethod
                {
                    Name = "Hello",
                    Attributes = MemberAttributes.Public
                };
    
                cmm.Statements.Add(cmie);
                ctd.Members.Add(cmm);
                cns.Types.Add(ctd);
                ccu.Namespaces.Add(cns);
    
                var provider = new CSharpCodeProvider();
                var parameters = new CompilerParameters
                {
                    CompilerOptions = "/target:library /optimize",
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };
    
                ////parameters.ReferencedAssemblies.Add("System.dll");
    
                var results = provider.CompileAssemblyFromDom(parameters, ccu);
    
                if (results.Errors.Count == 0)
                {
                    var t = results.CompiledAssembly.GetType("Aesop.Demo.Test");
                    var inst = results.CompiledAssembly.CreateInstance("Aesop.Demo.Test");
                    t.InvokeMember("Hello", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, inst, null);
                }
    
                Console.ReadLine();
            }
        }
    }
