    public Type BuildType(string propertyName)
        {
		    var code = @"
                using System;
                namespace MyNamespace
                {
                    public class MyClass
                    {
						public object " + propertyName + @" { get; set; }
                    }
                }";
			
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };
			
            var results = provider.CompileAssemblyFromSource(parameters, code);
            // Check Errors
            if (results.Errors.HasErrors)
            {
                var sb = new StringBuilder();
                foreach (CompilerError error in results.Errors) 
				{
					sb.AppendLine(string.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
				}
                throw new InvalidOperationException(sb.ToString());
            }
            var assembly = results.CompiledAssembly;
            var classInstance = assembly.GetType("MyNamespace.MyClass");
            return classInstance;
        }
