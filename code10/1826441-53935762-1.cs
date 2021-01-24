    using System;
    using System.Collections.Generic;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Reflection;
    
    public class Folders
    {
    
        public static void Main(string[] args)
        {
            try
            {
                var source = @"using System;
    
    public static class DymamicClass
    {
        public static string TestValue()
        {
            var items = new string[] { ""item1"", ""item2"" };
                return items[9];
            }
    
        }";
                CSharpCodeProvider Compiler = new CSharpCodeProvider();
                List<string> importDlls = new List<string>(new string[] { "System.dll", "System.Data.dll" });
    
                CompilerParameters compilerPars = new CompilerParameters(importDlls.ToArray());
                compilerPars.GenerateInMemory = true;
                compilerPars.IncludeDebugInformation = true;
                compilerPars.CompilerOptions += " /debug:pdbonly";
    
                string path = Assembly.GetExecutingAssembly().Location;
                compilerPars.ReferencedAssemblies.Add(path);
    
                CompilerResults Results = Compiler.CompileAssemblyFromSource(compilerPars, source);
    
                Assembly assembly = Results.CompiledAssembly;
                Type program = assembly.GetType("DymamicClass");
                MethodInfo main = program.GetMethod("TestValue");
                main.Invoke(null, null);
            }
            catch (Exception e)
            {
                var trace = new System.Diagnostics.StackTrace(e.InnerException, true);
                if (trace.FrameCount > 0)
                {
                    var frame = trace.GetFrame(trace.FrameCount - 1);
                    var className = frame.GetMethod().ReflectedType.Name;
                    var methodName = frame.GetMethod().ToString();
                    var lineNumber = frame.GetFileLineNumber();
                }
            }
        }
    }
