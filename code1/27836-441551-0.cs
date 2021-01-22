    public delegate void TreeActionDelegate(WhatToDo details);
    public void DoSomethingWithThisTree(WhatToDo details)
    {
        // Assuming that 'this' points to a TreeView
        if (this.InvokeRequired) this.Invoke(new TreeActionDelegate(),
            new object[] { details });
        else
        {
            // The body of your function
        }
    }
