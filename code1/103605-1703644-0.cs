    private Action<Process> removeBreakpoint = p => p.RemoveBreakpoint();
    private Action<Process> addBreakpoint = p => p.AddBreakpoint(); 
    void DoSingleAction(Action<Process> action)
    {
         var p = GetProcess(viewer);
         if(p != null)
         {
             action(p); //invokes the action
             BeginRefresh(null,null);
         }
    }
    void DoListAction(Action<Process> action)
    {
        lvwProcessList.ForEach(action);
        BeginRefresh(false, false);
    }
    private void ctxgrphAddBreakpoint_Click(object sender, EventArgs e)
    {
        DoSingleAction(addBreakpoint);
    }
    private void ctxgrphRemoveBreakpoint_Click(object sender, EventArgs e)
    {
        DoSingleAction(removeBreakpoint);
    }
    private void ctxlistAddBreakpoint_Click(object sender, EventArgs e)
    {
        DoListAction(addBreakpoint);
    }
    private void ctxlistRemoveBreakpoint_Click(object sender, EventArgs e)
    {
        DoListAction(removeBreakpoint);
    }
