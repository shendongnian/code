    public MainForm()
    {
        //in your constructor, create all your common methods, actions, etc and save them to private vars
        //Then in your form:
        ToolStripMenu menu = new ToolStripMenu();
        AttachCommonFunctionality(menu);
        Items.Add(menu);
        ContextMenuStrip rightClick = new ContextMenuStrip();
        AttachCommonFunctionality(rightClick);
        this.ContextMenu = rightClick;
        //etc...
    }
    private void AttachCommonFuntionality(Control c)
    {
        c.Items.Add(_item1);
        c.Items.Add(_item2);
        //etc...
    
        c.OnClick += _myCommonAction;
        //etc...
    }
