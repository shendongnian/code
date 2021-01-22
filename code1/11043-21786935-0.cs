    protected override void OnInit(EventArgs e)
    {
        //...
        if (ScriptManager.GetCurrent(this.Page) == null)
        {
            ScriptManager scriptManager = new ScriptManager();
            scriptManager.ID = "scriptManager_" + DateTime.Now.Ticks;
            Controls.AddAt(0, scriptManager);
        }
        //...
    }
