    protected void grdList_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        var grid = sender as ASPxGridView;
    
        // make sure Cancel property set to true
        e.Cancel = true;
        
        // row deleting code here
        // data rebinding code here
        grdList.DataBind();
    }
