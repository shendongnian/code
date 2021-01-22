    var ctx = new ModelContainer();
    // ...
    ctx.ObjectStateManager.ObjectStateManagerChanged += (sender, e) =>
    {
       Trace.WriteLine(string.Format("{0}, {1}", e.Action, e.Element));
    };
