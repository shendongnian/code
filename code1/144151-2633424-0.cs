        private void GoogleChart(HttpContext cxt)
		{            
            const string csPrefix = "?act=chrt&req=chart&";
			HttpRequest		req = cxt.Request;
			HttpResponse	rsp = cxt.Response;
			string			sUrl = cxt.Request.RawUrl;
			int				nStart = sUrl.IndexOf(csPrefix,  StringComparison.OrdinalIgnoreCase);
			rsp.Clear();
			if (nStart > 0)
			{
				sUrl = "http://chart.apis.google.com/chart?" + sUrl.Substring(nStart + csPrefix.Length);
				System.Net.WebClient	wc = new System.Net.WebClient();
				byte[] buffer = wc.DownloadData(sUrl);
				cxt.Response.ClearContent();
				cxt.Response.ClearHeaders();
				cxt.Response.ContentType = "application/octet-stream";
				cxt.Response.AppendHeader("content-length", buffer.Length.ToString());				
				cxt.Response.BinaryWrite(buffer);
			}
		}
