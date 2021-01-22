    private Control FindTable(Control startFrom)
    {
        foreach(Control child in startFrom.Controls)
        {
            if(child is System.Web.UI.WebControls.Table)
            {
                return child;
            }
            else
            {
                return FindTable(child);
            }
        }
        return null;
    }
