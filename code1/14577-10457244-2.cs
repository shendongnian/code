    using System;
    using System.Collections.Generic;
    
    namespace RuntimeCompilationTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stopWatch = new System.Diagnostics.Stopwatch();
                stopWatch.Start();
    
                string codeToCompile = @"
                    public class SomeClass
                    {
                        public int Add42 (int parameter)
                        {
                            return parameter += 42;
                        }
                    }";
    
                Dictionary<string, string> providerOptions = new Dictionary<string, string>
                    {
                        {"CompilerVersion", "v4.0"}
                    };
                var csCodeProvider = new Microsoft.CSharp.CSharpCodeProvider(providerOptions);
    
                var compilerParameters = new System.CodeDom.Compiler.CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };
                System.CodeDom.Compiler.CompilerResults compilerResults = csCodeProvider.CompileAssemblyFromSource(compilerParameters, codeToCompile);
                
                stopWatch.Stop();
                Console.WriteLine(string.Format("compile time: {0}", stopWatch.Elapsed));
                stopWatch.Restart();
                
                object typeInstance = compilerResults.CompiledAssembly.CreateInstance("SomeClass");
                System.Reflection.MethodInfo mi = typeInstance.GetType().GetMethod("Add42");
    
                int i, methodOutput;
                var parameterList = new object[1];
                for (i = 0; i < 1000000; i++)
                {
                    parameterList[0] = i;
                    methodOutput = (int)mi.Invoke(typeInstance, parameterList);
                }
    
                stopWatch.Stop();
                Console.WriteLine(string.Format("time to call function {0} times: {1}", i.ToString("##,#"), stopWatch.Elapsed));
    
                stopWatch.Restart();
    
                for (i = 0; i < 1000000; i++)
                {
                    methodOutput = Add43(i);
                }
    
                stopWatch.Stop();
                Console.WriteLine(string.Format("time to call function {0} times: {1}", i.ToString("##,#"), stopWatch.Elapsed));
    
                Console.ReadLine();
            }
    
            private static int Add43(int parameter)
            {
                return parameter += 43;
            }
        }
    }
