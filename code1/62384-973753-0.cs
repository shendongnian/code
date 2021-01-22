    private void AddHistoryPoint(String key, String value, String tile)
    {
        ScriptManager scm = ScriptManager.GetCurrent(this.Page);
        if ((scm.IsInAsyncPostBack == true) && (scm.IsNavigating != true))
        {
            if (pageState == null)
            {
               NameValueCollection pageState = new NameValueCollection();
            }
            if (pageState[key] != null)
            {
                pageState[key] = value;
            }
            else
            {
                pageState.Add(key, value);
            }
            scm.AddHistoryPoint(pageState, tile);
        }
    }
    protected void grid_PageIndexChanged1(object sender, EventArgs e)
    {
        AddHistoryPoint("pi", grdProject.PageIndex.ToString(), "Page Index- " + (grdProject.PageIndex + 1).ToString());
    }
