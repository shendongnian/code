    public class AspHost : MarshalByRefObject
	{
		public string _VirtualDir;
		public string _PhysicalDir;
		public string ViewToString<T>(string aspx, Dictionary<string, object> viewData, T model)
		{
			StringBuilder sb = new StringBuilder();
			using (StringWriter sw = new StringWriter(sb))
			{
				using (HtmlTextWriter tw = new HtmlTextWriter(sw))
				{
					var workerRequest = new SimpleWorkerRequest(aspx, "", tw);
					HttpContext.Current = new HttpContext(workerRequest);
					ViewDataDictionary<T> viewDataDictionary = new ViewDataDictionary<T>(model);
					foreach (KeyValuePair<string, object> pair in viewData)
					{
						viewDataDictionary.Add(pair.Key, pair.Value);
					}
					object view = BuildManager.CreateInstanceFromVirtualPath(aspx, typeof(object));
					ViewPage viewPage = view as ViewPage;
					if (viewPage != null)
					{
						viewPage.ViewData = viewDataDictionary;
					}
					else
					{
						ViewUserControl viewUserControl = view as ViewUserControl;
						if (viewUserControl != null)
						{
							viewPage = new ViewPage();
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
