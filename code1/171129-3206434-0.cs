    void myGridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		MyObject myObj = (myObj)e.Row.DataItem;
    		if (myObj.flag) {
    			CheckBox cb = (CheckBox)e.Row.FindControl("myCheckBox");
    			cb.Enabled=false;
    		}
    	}
    }
