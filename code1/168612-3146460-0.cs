    /// <summary>
    /// Handles gridview row data bound event.
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">Event Argument</param>
    protected void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // We don’t want to apply this to headers.
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                //your data-object that is rendered in this row, if at all required.
                //Object obj = e.Row.DataItem;
                //find the right color from condition
                string color = condition ? "#ff9900" : "some-other-color";
                //set the backcolor of the cell based on the condition
                e.Row.Cells[4].Attributes.Add("Style", "background-color: " + color + ";");
            }
            catch
            {
            }
        }
    }
