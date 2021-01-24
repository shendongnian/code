    private bool MarkerWasClicked = false;
    
    private void gmap_mainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
    {
    	MarkerWasClicked = false;
    	
    	if (MarkerWasClicked == false){
    		if (e.Button == System.Windows.Forms.MouseButtons.Left && item.IsMouseOver){
    			MessageBox.Show("Marker clicked", "Information");
    			MarkerWasClicked = true;
    		}
    	}
    }
