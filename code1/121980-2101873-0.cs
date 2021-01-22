    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataBoundItem = e.Item as GridDataItem;
            if (dataBoundItem["ColumnName"].Text.Length > 100)
            {
                dataBoundItem["ColumnName"].Text = dataBoundItem["ColumnName"].Text.Substring(0, 100) + "...";
            }
        }
    }
