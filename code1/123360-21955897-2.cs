    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
    	    URLSecurityZoneAPI.InternetSetFeatureEnabled(URLSecurityZoneAPI.InternetFeaturelist.DISABLE_NAVIGATION_SOUNDS, URLSecurityZoneAPI.SetFeatureOn.PROCESS, true);
    	
    		var browser = new AxWebBrowser();
    		var hostForm = new Form();
    		hostForm.Width = 0;
    		hostForm.Height = 0;
    		hostForm.ShowInTaskbar = false;
    		hostForm.ControlBox = false;
    		hostForm.ShowIcon = false;
    		hostForm.MinimizeBox = false;
    		hostForm.MaximizeBox = false;
    		hostForm.Controls.Add(browser);
    		hostForm.Show();
    		hostForm.Hide();
    
    		browser.DocumentComplete += delegate(object sender, DWebBrowserEvents2_DocumentCompleteEvent e)
    		{
    			var doc = (IHTMLDocument3)browser.Document;
    			Console.WriteLine(doc.documentElement.innerHTML);
    		};
    
    		browser.Navigate("www.google.com");
    
    		while (true) 
    			System.Windows.Forms.Application.DoEvents();
        }
    }
