    public class Evaluator
    {
        public static object MyStr(string statement)
        {
            return _evaluatorType.InvokeMember(
                        "MyStr",
                        BindingFlags.InvokeMethod,
                        null,
                        _evaluator,
                        new object[] { statement }
                     );
        }
        static Evaluator()
        {
            ICodeCompiler compiler;
            compiler = new JScriptCodeProvider().CreateCompiler();
            CompilerParameters parameters;
            parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            CompilerResults results;
            results = compiler.CompileAssemblyFromSource(parameters, _jscriptSource);
            Assembly assembly = results.CompiledAssembly;
            _evaluatorType = assembly.GetType("Evaluator.Evaluator");
            _evaluator = Activator.CreateInstance(_evaluatorType);
        }
        private static object _evaluator = null;
        private static Type _evaluatorType = null;
        private static readonly string _jscriptSource =
            @"package Evaluator
            {
               class Evaluator
               {
                  public function MyStr(expr : String) : String 
                  { 
                     var x;
                     eval(""x='""+expr+""';"");
                     return x;
                  }
               }
            }";
    }
