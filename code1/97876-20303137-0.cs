    protected void Score_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
    {
        if (e.Item is RadListViewItem)
        {
            RadListViewDataItem item = e.Item as RadListViewDataItem;
            object dataItem = ((System.Data.DataRowView)(((RadListViewDataItem)e.Item).DataItem)).Row.ItemArray[2].ToString();
            string raetest = Convert.ToString(dataItem);
        }
    }
