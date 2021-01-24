    using IronPython.Hosting;
    namespace PythonFromCSharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine();
                Microsoft.Scripting.Hosting.ScriptScope s = py.CreateScope();
            
                py.Execute(
    @"import numpy as np 
    incomes = np.random.normal(27000, 15000, 10000) 
    x = np.mean(incomes)"
                , s);
            }
        }
    }
