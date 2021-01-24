    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
           //if you want to get label text from gridview then do like this
          System.Web.UI.WebControls.label lbl = ((System.Web.UI.WebControls.label)GridView1.SelectedRow.Cells[0].FindControl("LabelID"));//put lebelid here
          string labelText = lbl.Text;
    	  
    	  // if you want to get textbox text from gridview then do like this
    	    System.Web.UI.WebControls.TextBox txt = ((System.Web.UI.WebControls.TextBox)gvTest.SelectedRow.Cells[0].FindControl("TextboxID"));//put textboxID here
             string textBoxText = txt.Text;    		     		 
    		 //your code Here    
    }
