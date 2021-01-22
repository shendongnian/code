    //these two are in a separate static class
    public static InvokeAction(this ListView listView, Action<Process> action)
    { ... }
    public static InvokeAction(this GraphView listView, Action<Process> action)
    { ... }
    private void handler(object sender, Action<Process> action)
    { 
        var lv = sender as ListView;
        var gv = sender as GraphVeiw;    
        lv.InvokeAction(action); //(need to check for null first)
        gv.InvokeAction(action);
        if(lv == null && gv == null) {throw new Exception("sender is not ListView or GraphView");}
    }
        
    //then update all the handlers:
    private void ctxgrphAddBreakpoint_Click(object sender, EventArgs e)
    {
        handler(sender, addBreakpoint);
    }
