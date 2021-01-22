    public class AspHost : MarshalByRefObject
    {
		public string _VirtualDir;
		public string _PhysicalDir;
		public string AspxToString(string aspx)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter tw = new HtmlTextWriter(sw))
                {
                    var workerRequest = new SimpleWorkerRequest(aspx, "", tw);
                    HttpContext.Current = new HttpContext(workerRequest);
    
                    object view = BuildManager.CreateInstanceFromVirtualPath(aspx, typeof(object));
    
                    Page viewPage = view as Page;
                    if (viewPage == null)
                    {
                        UserControl viewUserControl = view as UserControl;
                        if (viewUserControl != null)
                        {
                            viewPage = new Page();
                            viewPage.Controls.Add(viewUserControl);
                        }
                    }
    
                    if (viewPage != null)
                    {
                        HttpContext.Current.Server.Execute(viewPage, tw, true);
    
                        return sb.ToString();
                    }
    
                    throw new InvalidOperationException();
                }
            }
        }
		public static AspHost SetupFakeHttpContext(string physicalDir, string virtualDir)
		{
			return (AspHost)ApplicationHost.CreateApplicationHost(
				typeof(AspHost), virtualDir, physicalDir);
		}
	}
