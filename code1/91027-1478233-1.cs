    protected void uxSourceGrid_RowDrop(object sender, 
                   Telerik.Web.UI.GridDragDropEventArgs e)
    {
        for (int i = 0; i < e.DraggedItems.Count; i++)
        {
            if (e.DestinationGrid.ID == uxRequiredDateGrid.ID)
            {
                SqlDataSource3.UpdateCommand = 
                      "UPDATE Orders SET RequiredDate = 
                       current_timestamp WHERE OrderID =" +
                       e.DraggedItems[i].GetDataKeyValue("OrderID");
                SqlDataSource3.Update();
                uxRequiredDateGrid.Rebind();
            }
            else
            {
                SqlDataSource1.UpdateCommand = 
                      "update orders set shippeddate = 
                       current_timestamp where orderid =" +
                       e.DraggedItems[i].GetDataKeyValue("OrderID");
                SqlDataSource1.Update();
                uxSourceGrid.Rebind();
            }
        }
    }
