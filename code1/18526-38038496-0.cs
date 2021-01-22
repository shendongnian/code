    public void SoftRefreshPropertyGrid()
    {
    	 var peMain = propertyGrid.GetType().GetField("peMain", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(propertyGrid)as  System.Windows.Forms.GridItem;
    	 if (peMain != null)
    	 {
    		   var refreshMethod = peMain.GetType().GetMethod("Refresh");
    		   if (refreshMethod != null)
    		   {
    				  refreshMethod.Invoke(peMain, null);
    				  propertyGrid.Invalidate(true);
    		   }
    	 }
    }
