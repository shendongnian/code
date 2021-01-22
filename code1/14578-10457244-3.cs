    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    
    namespace RuntimeCompilationTest {
        class Program
        {
            static void Main(string[] args) {
                string sourceCode = @"
                    public class SomeClass {
                        public int Add42 (int parameter) {
                            return parameter += 42;
                        }
                    }";
                var compParms = new CompilerParameters{
                    GenerateExecutable = false, 
                    GenerateInMemory = true
                };
                var csProvider = new CSharpCodeProvider();
                CompilerResults compilerResults = 
                    csProvider.CompileAssemblyFromSource(compParms, sourceCode);
                object typeInstance = 
                    compilerResults.CompiledAssembly.CreateInstance("SomeClass");
                MethodInfo mi = typeInstance.GetType().GetMethod("Add42");
                int methodOutput = 
                    (int)mi.Invoke(typeInstance, new object[] { 1 }); 
                Console.WriteLine(methodOutput);
                Console.ReadLine();
            }
        }
    }
