    static void getPythonFunc(Foo foo) {
        
        ScriptRuntimeSetup setup = ScriptRuntimeSetup.ReadConfiguration();
        ScriptRuntime runtime = new ScriptRuntime(setup);
        runtime.LoadAssembly(Assembly.GetExecutingAssembly());
        ScriptEngine engine = runtime.GetEngine("IronPython");
        ScriptScope scope = engine.CreateScope();
    
        engine.ExecuteFile("filter.py", scope);
    
        var filterFunc = scope.GetVariable("filter_item");
        scope.Engine.Operations.Invoke(filterFunc, foo);
    }
