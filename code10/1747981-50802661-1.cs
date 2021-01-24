    public void action1Func(int p1) //action 1 has one int parameter
    {
    }
    public void action2Func() //let's consider action 2 takes no parameters
    {
    }
    public void action3Func(int p1, int p2, int p3)
    {
    }
    // Order of parameters was changed to leverage implicit null parameters for convenience
    // See invocations below
    public void execAction(theActions action, 
                           int? inVar1 = null, int? inVar2 = null, int? inVar3 = null) 
    {
        switch (action) // Based on action kind, invoke the right function.
        {               // The mapping is now coded in a switch statement 
                        // instead of a Dictionary declaration
            case theActions.action1: action1Func(inVar1.Value); break;
            case theActions.action2: action2Func(); break;
            case theActions.action3: action3Func(inVar1.Value, inVar2.Value, inVar3.Value); break;
        }
    }
    // Invocations
    execAction(theActions.action1, 1);
    execAction(theActions.action2);
    execAction(theActions.action3, 1, 3, 5);
