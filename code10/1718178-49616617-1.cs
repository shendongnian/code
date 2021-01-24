    using Roslyn.Scripting.CSharp;
     
    namespace RoslynScriptingDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var engine = new ScriptEngine();
                engine.Execute(@"System.Console.WriteLine(""Hello Roslyn"");");
            }
        }
    }
