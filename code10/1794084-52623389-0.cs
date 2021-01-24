        var dyncode = "return param1 + \" \" + param2;";
        CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
                
      string src = @"
        using System;
        using System.Text;
        using System.Text.RegularExpressions;
        public class CustomTextFunction {
            public string f(string param1, string param2) {
                " + dyncode + @"
            }
        }
    ";
                var parameters = new CompilerParameters();
                parameters.ReferencedAssemblies.Add("System.dll");
    
    
    
                CompilerResults compiled = provider.CompileAssemblyFromSource(parameters, src);
                if (compiled.Errors.Count == 0)
                {
                    Type type = compiled.CompiledAssembly.GetType("CustomTextFunction");
                    Console.WriteLine((string)type.GetMethod("f").Invoke(Activator.CreateInstance(type), new string[] { "Hello", "World" }));
                }
                else
                {
                    foreach (object error in compiled.Errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                }
                Console.ReadKey();
