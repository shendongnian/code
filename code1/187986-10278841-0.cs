    public partial class MainWindow 
    {
    	bool IsAboutWindowOpen = false;
    	
    	private void Help_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    	{
    		if (!IsAboutWindowOpen)
    		{
    			var aboutWindow = new About();
    			aboutWindow.Closed += new EventHandler(aboutWindow_Closed);
    			aboutWindow.Show();
    			IsAboutWindowOpen = true;
    		}
    	}
    
    	void aboutWindow_Closed(object sender, EventArgs e)
    	{
    		IsAboutWindowOpen = false;
    	}
    }
