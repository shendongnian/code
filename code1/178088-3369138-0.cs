    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    
    			string html = "<P align=center><SPAN style=\"FONT-FAMILY: Arial; FONT-SIZE: 10px\"><SPAN style=\"COLOR: #666666\">View the </SPAN><A href=\"http://www.google.com\"><SPAN style=\"COLOR: #666666\">online version</SPAN></A><SPAN style=\"COLOR: #666666\"> if you are having trouble <A name=hi>displaying </A>this <a name=\"msg\">message</A></SPAN></SPAN></P>";
    			string fileName = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
    			System.IO.File.WriteAllText(fileName, html);
    
    			var browser = new WebBrowser();
    			browser.Navigated += (sender, e) => browser_Navigated(sender, e);
    			browser.Navigate(new Uri(fileName));
    		}
    
    		private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
    		{
    			var browser = (WebBrowser)sender;
    			var links = browser
                            .Document
                            .Links
                            .OfType<HtmlElement>()
                            .Select(l => ((mshtml.HTMLAnchorElement)l.DomElement).href); 
                            //result: { "http://www.google.com", .. }
    		}
    	}
    }
