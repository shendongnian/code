    protected void Page_Load(object sender, EventArgs e)
    {              
        this.Master.ScriptManager.Navigate += 
        new EventHandler<HistoryEventArgs>(ScriptManager_Navigate);
        if (!this.IsPostBack && !ScriptManager.GetCurrent(this).IsInAsyncPostBack)
        {
            // load default multiview index
        }           
    }
