    protected void grdList_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        var grid = sender as ASPxGridView;
        
        try 
        {
            // row deleting code here
    
            // data rebinding code here
            grdList.DataBind();
        }
        catch (Exception e)
        {
            // exception handling
        }
        finally
        {
            // make sure Cancel property set to true
            e.Cancel = true;
        }
    }
