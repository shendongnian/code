        public static string ParseString(string txt)
        {
            var provider = new Microsoft.CSharp.CSharpCodeProvider();
            var prms = new System.CodeDom.Compiler.CompilerParameters();
            prms.GenerateExecutable = false;
            prms.GenerateInMemory = true;
            var results = provider.CompileAssemblyFromSource(prms, @"
    namespace tmp
    {
        public class tmpClass
        {
            public static string GetValue()
            {
                 return " + "\"" + txt + "\"" + @";
            }
        }
    }");
            System.Reflection.Assembly ass = results.CompiledAssembly;
            var method = ass.GetType("tmp.tmpClass").GetMethod("GetValue");
            return method.Invoke(null, null) as string;
        }
