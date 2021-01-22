    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.SelectionChanged += CalendarSelectionChanged;
    }
     
    private void CalendarSelectionChanged(object sender, EventArgs e)
    {
        DateTime selectedDate = ((Calendar) sender).SelectedDate;
        string url = "HistoryRates.aspx?date="
    + HttpUtility.UrlEncode(selectedDate.ToShortDateString());
        ScriptManager.RegisterClientScriptBlock(this, GetType(),
    "rates" + selectedDate, "openWindow('" + url + "');", true);
    }
