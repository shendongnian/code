    var readOnlyDict = new ReadOnlyDictionary<string, PSObject>(new Dictionary<string, PSObject>(){
        { "initKey1", initPSobject1 },
        { "initKey2", initPSobject2 },
    });
    SessionState.PSVariable.Set(new PSVariable(paramContainerName, readOnlyDict, ScopedItemOptions.Private | ScopedItemOptions.ReadOnly))
