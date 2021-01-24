c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PythonScriptExecution2
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Scripting.Hosting.ScriptEngine eEngine =
                IronPython.Hosting.Python.CreateEngine();
            // We execute this script from Visual Studio 
            // so the program will be executed from bin\Debug or bin\Release
            Microsoft.Scripting.Hosting.ScriptSource pythonScript =
            ICollection<string> searchPaths = engine.GetSearchPaths();
            searchPaths.Add(@"C:\Users\abc\CSharp\PythonScriptExecution1\packages\IronPython.2.7.9\lib");
            searchPaths.Add(@"C:\Users\abc\PycharmProjects\untitled3\venv\Lib");
            engine.SetSearchPaths(searchPaths);
            engine.CreateScriptSourceFromFile("C:/Users/abc/PycharmProjects/untitled3/test.py");
            pythonScript.Execute();
        }
    }
}
