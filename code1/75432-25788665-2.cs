    protected void hfSiteTypesBnd( object sender, EventArgs e )
    {
        // read the value
    	HiddenField hf = (HiddenField)sender;
    	short val = Convert.ToInt16( hf.Value );
        // find the checkboxlist
    	CheckBoxList cblSiteTypes = (CheckBoxList)hf.Parent.FindControl( "cblSiteTypes" );
        // clear the selection (may be not needed)
    	cblSiteTypes.ClearSelection();
        // for each item
    	foreach ( ListItem li in cblSiteTypes.Items )
    	{
            // get the value from each item and...
    		short v = Convert.ToInt16( li.Value );
            // ...look up whether this value is matching or not
    		if ( ( val & v ) == v ) li.Selected = true;
    	}
    }
