    namespace DynamicCompilation
    {
        using System;
        using System.CodeDom;
        using System.CodeDom.Compiler;
        using System.Reflection;
    
        using Microsoft.CSharp;
    
        internal static class Program
        {
            private static void Main(string[] args)
            {
                CodeCompileUnit cu = new CodeCompileUnit();
                CodeNamespace ns = new CodeNamespace("Aesop.Demo");
    
                ns.Imports.Add(new CodeNamespaceImport("System"));
    
                CodeTypeDeclaration ctd = new CodeTypeDeclaration("Test")
                {
                    TypeAttributes = TypeAttributes.Public
                };
                CodeTypeReferenceExpression ctre = new CodeTypeReferenceExpression("System.Console");
                CodeMethodInvokeExpression cmie = new CodeMethodInvokeExpression(ctre, "WriteLine", new CodePrimitiveExpression("Hello World!"));
                CodeMemberMethod cmm = new CodeMemberMethod
                {
                    Name = "Hello",
                    Attributes = MemberAttributes.Public
                };
    
                cmm.Statements.Add(cmie);
                ctd.Members.Add(cmm);
                ns.Types.Add(ctd);
                cu.Namespaces.Add(ns);
    
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters
                {
                    CompilerOptions = "/target:library /optimize",
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };
    
                CompilerResults results = provider.CompileAssemblyFromDom(parameters, cu);
    
                if (results.Errors.Count == 0)
                {
                    Type t = results.CompiledAssembly.GetType("Plattform.Demo.Test");
                    object inst = results.CompiledAssembly.CreateInstance("Plattform.Demo.Test");
                    t.InvokeMember("Hello", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, inst, null);
                }
    
                Console.ReadLine();
            }
        }
    }
