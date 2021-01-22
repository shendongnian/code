    for (int i = 0; i <= GridView1.Rows.Count - 1; i++) {
       
        button btnedit = new button();
       
       
        GridView1.Rows(i).Cells(3).Controls.Add(btnedit);
       //the above is where you want the button to be on the grid
        btndel.CommandName = "Select2";
        btndel.CommandArgument = "whatever you want";
    }
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select1" Then 
            
           //do stuff
    End Sub
              
