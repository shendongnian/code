    var objOps = _engine.Operations;
    var lib = new Lib();
    
    foreach (string memberName in objOps.GetMemberNames(lib)) {
        _scope.SetVariable(memberName, objOps.GetMember(lib, memberName));
    }
