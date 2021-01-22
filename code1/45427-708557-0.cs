    using System;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    
    class Test
    {
        public static void Main(string[] args)
        {
            string code = @"
    using System;
    
    class CodeToBeCompiled
    {
        static void Main()
        {
            Console.WriteLine(""Hello world"");
        }
    }";
    
            var codeProvider = new CSharpCodeProvider();
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = "Generated.exe"
            };
            var results = codeProvider.CompileAssemblyFromSource
                (parameters, new[] { code });
            results.CompiledAssembly.EntryPoint.Invoke(null, null);
        }
    }
