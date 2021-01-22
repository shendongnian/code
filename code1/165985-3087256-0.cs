    private class CommonControl : Control
    {
        public CommonControl(Control host)
        {
            //new() up your common methods, actions, etc...
    
            host.Items.Add(item1);
            host.Items.Add(item2);
            //etc...
    
            host.OnClick += myCommonAction;
            //etc...
        }
    }
    //Then in your form:
    Items.Add(new CommonControl(new ToolStripMenu()));
    Items.Add(new CommonControl(new ContextMenuStrip()));
    //etc...
