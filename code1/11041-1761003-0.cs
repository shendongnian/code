    protected void updatePanel1_Init(object sender, EventArgs e)
    {
         if (ScriptManager.GetCurrent(this.Page) == null)
         {
             ScriptManager sManager = new ScriptManager();
             sManager.ID = "sManager_" + DateTime.Now.Ticks;
             phScriptManager.Controls.AddAt(0, sManager);
         }
    }
