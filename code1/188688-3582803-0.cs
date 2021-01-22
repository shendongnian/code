using System;
using System.Reflection;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronRuby;
namespace Testing
{
    public class MainClass
    {
        public MainClass() { }
        public override string ToString() { return "Hello World"; }
        public static void Main()
        {
            ScriptEngine engine = IronRuby.Ruby.CreateEngine();
            engine.Runtime.LoadAssembly(Assembly.LoadFile(Assembly.GetExecutingAssembly().Location));
            ScriptScope scope = engine.CreateScope();
            String code = "p Testing::MainClass.new";
            ScriptSource script = engine.CreateScriptSourceFromString(code, SourceCodeKind.SingleStatement);
            script.Execute(scope);
        }
    }
}
