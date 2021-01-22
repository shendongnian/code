    public void updatePanel_Init(object sender, EventArgs e)
    {
        if (ScriptManager.GetCurrent(Page) == null)
        {
            ScriptManager sMgr = new ScriptManager();
            sMgr.EnablePartialRendering = true;
            sMgr_place.Controls.Add(sMgr);
        }
    }
