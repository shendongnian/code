    protected override void OnInit(EventArgs e)
    {
        Page.Init += delegate(object sender, EventArgs e_Init)
                     {
                         if (ScriptManager.GetCurrent(Page) == null)
                         {
                             ScriptManager sMgr = new ScriptManager();
                             Page.Form.Controls.AddAt(0, sMgr);
                         }
                     };
        base.OnInit(e);
    }
