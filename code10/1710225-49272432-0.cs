    int strPrevDisplayColumn = 0;
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView item = e.Item.DataItem as DataRowView;
        int strCurrentDisplayColumn = Convert.ToInt32(item["DisplayColumn"]);
        if (strCurrentDisplayColumn == strPrevDisplayColumn)
        {
            // Do something
        }
        strPrevDisplayColumn = strCurrentDisplayColumn;
    }
