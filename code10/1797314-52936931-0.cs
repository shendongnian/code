    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        //Create task pane object
        archiverTaskPane1 = new ArchiverTaskPane();
        customTaskPane = this.CustomTaskPanes.Add(archiverTaskPane1, "Title");
        //Add event handler for opening task pane
        customTaskPane.VisibleChanged += new EventHandler(customTaskPane_VisibleChanged);
        //Add event handler for Outlook's AdvancedSearch
        Globals.ThisAddIn.Application.AdvancedSearchComplete += new Outlook.ApplicationEvents_11_AdvancedSearchCompleteEventHandler(Application_AdvancedSearchComplete);
    }
    public void Application_AdvancedSearchComplete(Microsoft.Office.Interop.Outlook.Search SearchObject)
    {
        DataTable dt = new DataTable();
        OutlookFunctions oFunctions = new OutlookFunctions();
        dt = oFunctions.BuildResults(SearchObject.Results);
        this.archiverTaskPane1.DataGridFiller(dt);
    }
