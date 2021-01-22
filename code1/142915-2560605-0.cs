    public AttachToHandleEvent(Object obj, string EventName)
    {
        EventInfo mfi = obj.GetType().GetEvent(EventName);
        MethodInfo mobj = mfi.GetAddMethod();
        mobj.Invoke(obj, new object[] { Item_Click});
    }
    
    private void Item_Click(object sender, EventArgs e)
    {
        MessageBox.Show("lalala");
    }
    
    ToolStripMenuItem tool = new ToolStripMenuItem();
    AttachToHandleEvent(tool "Click");
