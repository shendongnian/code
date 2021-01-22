    protected void gvDocs_PreRender(object sender, System.EventArgs e)
    {
    
    	if (gvDocs.Rows.Count > 0) {
    
    		int m = gvDocs.FooterRow.Cells.Count;
    		for (int i = m - 1; i >= 1; i += -1) {
    			//7 is the number of the column with the applychanges button in it.
    			if (i != 8) {
    				gvDocs.FooterRow.Cells.RemoveAt(i);
    			}
    		}
    		gvDocs.FooterRow.Cells(1).ColumnSpan = 6;
    		//6 is the number of visible columns to span.
    	}
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================
