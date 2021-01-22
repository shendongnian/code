	private void axWebBrowser1_DocumentComplete( object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e )
	{
		try
		{
			Uri url = new Uri((string)e.uRL);
			string favicon = null;
			mshtml.HTMLDocument document = axWebBrowser1.Document as mshtml.HTMLDocument;
			if( document != null )
			{
				mshtml.IHTMLElementCollection linkTags = document.getElementsByTagName("link");
				foreach( object obj in linkTags )
				{
					mshtml.HTMLLinkElement link = obj as mshtml.HTMLLinkElement;
					if( link != null )
					{
						if( !String.IsNullOrEmpty(link.rel) && !String.IsNullOrEmpty(link.href) && 
							link.rel.Equals("shortcut icon",StringComparison.CurrentCultureIgnoreCase) )
						{
							//TODO: Bug - Can't handle relative favicon URL's
							favicon = link.href;
						}
					}
				}
			}
			if( String.IsNullOrEmpty(favicon) && !String.IsNullOrEmpty(url.Host) )
			{
				if( url.IsDefaultPort )
					favicon = String.Format("{0}://{1}/favicon.ico",url.Scheme,url.Host);
				else
					favicon = String.Format("{0}://{1}:{2}/favicon.ico",url.Scheme,url.Host,url.Port);
			}
			if( !String.IsNullOrEmpty(favicon) )
			{
				WebRequest request = WebRequest.Create(favicon);
				request.BeginGetRequestStream(new AsyncCallback(SetFavicon), request);
			}
		} 
		catch
		{
			this.Icon = null;
		}
	}
	private void SetFavicon( IAsyncResult result )
	{
		WebRequest request = (WebRequest)result.AsyncState;
		WebResponse response = request.GetResponse();
		Bitmap bitmap = new Bitmap(Image.FromStream(response.GetResponseStream()));
		this.Icon = Icon.FromHandle(bitmap.GetHicon());
	}
