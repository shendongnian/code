    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.CSharp;
    using System.CodeDom;
    using System.IO;
    using System.CodeDom.Compiler;
    using System.Reflection;
    
    namespace CodeDomQuestion
    {
        class Program
        {
    
            private static void Main(string[] args)
            {
                Program p = new Program();
                p.dotest("C:\\fs.exe");
            }
    
            public void dotest(string outputname)
            {
                CSharpCodeProvider cscProvider = new CSharpCodeProvider();
                CompilerParameters cp = new CompilerParameters();
                cp.MainClass = null;
                cp.GenerateExecutable = true;
                cp.OutputAssembly = outputname;
                
                CodeNamespace ns = new CodeNamespace("StackOverflowd");
    
                CodeTypeDeclaration type = new CodeTypeDeclaration();
                type.IsClass = true;
                type.Name = "MainClass";
                type.TypeAttributes = TypeAttributes.Public;
                
                ns.Types.Add(type);
    
                CodeMemberMethod cmm = new CodeMemberMethod();
                cmm.Attributes = MemberAttributes.Static;
                cmm.Name = "Main";
                cmm.Statements.Add(new CodeSnippetExpression("System.Console.WriteLine('f'zxcvv)"));
                type.Members.Add(cmm);
    
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(ns);
    
                CompilerResults results = cscProvider.CompileAssemblyFromDom(cp, ccu);
    
                foreach (CompilerError err in results.Errors)
                    Console.WriteLine(err.ErrorText + " - " + err.FileName + ":" + err.Line);
                Console.WriteLine();
            }
        }
    }
