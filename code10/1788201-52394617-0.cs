	void WebView_Navigating(object sender, WebNavigatingEventArgs e)
	{
		var url = e.Url;
		if (url.StartsWith("whatsapp://", StringComparison.InvariantCultureIgnoreCase))
		{
			try
			{
				Device.OpenUri(new Uri(e.Url));
			}
            // Can not catch Android exception type in NetStd/PCL library, so hack it...
			catch (Exception ex) when (ex.Message.StartsWith("No Activity found to handle Intent", StringComparison.InvariantCulture))
			{
				// WhatsApp not installed : Android.Content.ActivityNotFoundException: No Activity found to handle Intent
				Console.WriteLine(ex);
			}
		}
	}
