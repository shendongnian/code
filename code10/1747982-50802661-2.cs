    public void execAction1(int p1)
        => execAction(theActions.action1, p1);
    public void execAction2()
        => execAction(theActions.action2);
    public void execAction3(int p1, int p2, int p3)
        => execAction(theActions.action3, p1, p2, p3);
    // Invocations will be
    execAction1(1);
    execAction2();
    execAction3(1, 3, 5);
