    // IRONPYTHONPATH environment variable is not required. Core ironpython dll paths should be part of operating system path.
    ScriptEngine pyEngine = Python.CreateEngine();
    Assembly myclass = Assembly.LoadFile(Path.GetFullPath("calculator.dll"));
    pyEngine.Runtime.LoadAssembly(myclass);
    ScriptScope pyScope = pyEngine.Runtime.ImportModule("calculator");
    dynamic Calculator = pyScope.GetVariable("Calculator");
    dynamic calc = Calculator();
    int result = calc.add(4, 5);
