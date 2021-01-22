    protected void lvDynamicLabels_ItemDataBound( object sender, ListViewItemEventArgs e ) 
    { 
        if ( e.Item is ListViewDataItem ) 
        { 
            Label lbl = (Label)e.Item.FindControl( "lblStep" ); 
            lbl.Text = "Step " + (datasource.Count + 1).ToString();
            TextBox txt = (TextBox)e.Item.FindControl( "txtStep" ); 
            txt.Text = ( (ListViewDataItem)e.Item ).DataItem.ToString(); 
        } 
    } 
