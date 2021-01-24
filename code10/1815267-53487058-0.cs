    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    private static void doPython()
    {
        ScriptEngine engine = Python.CreateEngine();
        engine.ExecuteFile(@"test.py");
    }
