	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			// some startup code, removed for clearity
		}
		public override void Init()
		{
			base.Init();
			EndRequest += MvcApplication_EndRequest;
		}
		private void MvcApplication_EndRequest(object sender, EventArgs e)
		{
			if (
				HttpContext.Current.Request.Url.AbsolutePath == "/DownloadFileEndedWebsite/Home/Contact" // This should be adjusted.
				&& HttpContext.Current.Items.Contains("DownloadFilePath"))
			{
				var filePath = HttpContext.Current.Items["DownloadFilePath"];
				// Delete file here..
			}
		}
	}
