    private void ProcessCommand(AOSCommand command)
    {
        GameObject cube = GameObject.Find(command.ObjName);
        AOSDispatch dispatch = cube.GetComponent<AOSDispatch>()
        if(dispatch == null){ return; } // or debug or exception
        dispatch.Call(command);
    }
