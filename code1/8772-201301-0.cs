    private string searchQuery = null;
    private void SearchButton(object sender, EventArgs e)
    {
        searchQuery = searchBox.Text;
        var results = DataLayer.PerformSearch(searchQuery);
        CreateLinkButtonControls(results);
    }
    // We save both the base state object, plus our query string.  Everything here must be serializable.
    protected override object SaveViewState()
    {
        object baseState = base.SaveViewState();
        return new object[] { baseState, searchQuery };
    }
    // The parameter to this method is the exact object we returned from SaveViewState().
    protected override void LoadViewState(object savedState)
    {
        object[] stateArray = (object[])savedState;
        searchQuery = stateArray[1] as string;
        // Re-run the query
        var results = DataLayer.PerformSearch(searchQuery);
        // Re-create the exact same control tree as at the point of SaveViewState above.  It must be the same otherwise things will break.
        CreateLinkButtonControls(results);
        // Very important - load the rest of the ViewState, including our controls above.
        base.LoadViewState(stateArray[0]);
    }
