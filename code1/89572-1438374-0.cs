    string source = @"
    class MyType
    {
        public static int Evaluate(<!parameters!>)
        {
            return <!expression!>;
        }
    }
    ";
    
    string parameters = "int a, int b, int c";
    string expression = "a + b * c";
    
    string finalSource = source.Replace("<!parameters!>", parameters).Replace("<!expression!>", expression);
    
    CodeSnippetCompileUnit compileUnit = new CodeSnippetCompileUnit(finalSource);
    CodeDomProvider provider = new CSharpCodeProvider();
    
    CompilerParameters parameters = new CompilerParameters();
    
    CompilerResults results = provider.CompileAssemblyFromDom(parameters, compileUnit);
    
    Type type = results.CompiledAssembly.GetType("MyType");
    MethodInfo method = type.GetMethod("Evaluate");
    
    // The first parameter is the instance to invoke the method on. Because our Evaluate method is static, we pass null.
    int result = (int)method.Invoke(null, new object[] { 4, -3, 2 });
