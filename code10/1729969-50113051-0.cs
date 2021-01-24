        private void webview_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (page.Source.AbsoluteUri.Contains("access_token"))
            {
                DataPackage dataPackage = new DataPackage();
                string r3 = page.Source.AbsoluteUri;
                string ntoken = r3.Substring(r3.IndexOf("access_token") + 13);
                string token = ntoken.Substring(0, ntoken.IndexOf("&"));
                web.Visibility = Visibility.Collapsed;
             }
         }
