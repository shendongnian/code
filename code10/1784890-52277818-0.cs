    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	var vPag = vApp.ActivePage;
    	var shp1 = vPag.DrawRectangle(2,5,3,4.5);
    	var shp2 = vPag.DrawRectangle(4,7,5,6.5);
    	shp1.AutoConnect(shp2, Visio.VisAutoConnectDir.visAutoConnectDirRight);
    	//Assuming 'No theme' is set for the page, no arrow will 
    	//be shown so change theme to see connector arrow
    	vPag.SetTheme("Office Theme");
    }
