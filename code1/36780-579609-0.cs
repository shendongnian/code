    ScriptEngine engine = Python.CreateEngine();
    ScriptSource source = engine.CreateScriptSourceFromFile("Calculator.py");
    ScriptScope scope = engine.CreateScope();
    ObjectOperations op = engine.Operations;
    source.Execute(scope); // class object created
    object klaz = scope.GetVariable("Calculator"); // get the class object
    object instance = op.Call(klaz); // create the instance
    object method = op.GetMember(instance, "add"); // get a method
    int result = (int)op.Call(method, 4, 5); // call method and get result (9)
