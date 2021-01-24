    public static DataTable RunAdvancedSearch(string[] searchFolders, string[] searchCriteria)
    {
        //Get Outlook namespace
        var oApp = Globals.ThisAddIn.Application;
        var oNS = oApp.GetNamespace("mapi");
        Microsoft.Office.Interop.Outlook.Search advSearch = null;
        //Do other stuff to properly set up the scope and filter
        //...
        //Perform search
        SearchComplete = false;
        try
        {
            advSearch = oApp.AdvancedSearch(scope, filter, false, "Archiver Search");
        }
        catch (System.Exception ex)
        {
            MessageBox.Show("An error has occurred during the search for emails. \n \n"
                    + ex.Message);
        }
    }
    public DataTable BuildResults(Results searchResults)
    {
        DataTable resultTable = new DataTable();
        //Do stuff to build DataTable from search results
        //...
        return resultTable;
    }
