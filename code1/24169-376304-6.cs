    public void RegisterUpdatePanel(UpdatePanel panel)
    {
        MethodInfo m =
            (from methods in typeof (ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
             where methods.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")
             select methods).First();
        m.Invoke(ScriptManager.GetCurrent(Page), new object[] {panel});
    }
    protected override void CreateChildControls()
    {
        for (int i = 0; i < Controls.Count; i++)
            if (Controls[i] is MyLastControl)
                while (i + 2 < Controls.Count)
                {
                    // In cas there is an updatepanel in the control we are moving
                    // We are registering an event to register the updatepanel
                    // to the scriptmanager again
                    SearchUpdatePanel(Controls[i + 2]);
                    plhContent.Controls.Add(Controls[i + 2]);
                }
        base.CreateChildControls();
    }
    private void SearchUpdatePanel(Control control)
    {
        if (control is UpdatePanel)
            control.Unload += updPnl_Unload;
        foreach (Control childcontrol in control.Controls)
            SearchUpdatePanel(childcontrol);
    }
    protected void updPnl_Unload(object sender, EventArgs e)
    {
        RegisterUpdatePanel((UpdatePanel) sender);
    }
