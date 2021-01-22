    void DoAction(object sender, Action<Process>)
    {
         if(sender is ListView)
         {
             lvwProcessList.ForEach(action);
             BeginRefresh(false, false);
         }
         else if (sender is GraphView)
         {
             var p = GetProcess(viewer);
             if(p != null)
             {
                 action(p); //invokes the action
                 BeginRefresh(null,null);
             }
         }
         else {throw new Exception("sender is not ListView or GraphView");}
    }
    //and update all the handlers to use this, and delete DoSingleAction and DoListAction:
    private void ctxgrphAddBreakpoint_Click(object sender, EventArgs e)
    {
        DoAction(sender, addBreakpoint);
    }
    //etc.
