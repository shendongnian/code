     protected void OrdersGridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e) { 
     if (e.Exception != null) { 
        lblStatus.Text = e.Exception.ToString(); 
       } 
       else 
       {
        string sValue = ((HiddenField)OrdersGridView.SelectedRow.Cells[1].FindControl("HiddenField1")).Value; lblStatus.Text = sValue; 
        } 
     }
