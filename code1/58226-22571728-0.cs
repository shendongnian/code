           try
            {
                if (webBrowser.Url.Equals("about:blank")) //first time visit
                {
                    webBrowser.Navigate(new Uri("http://url"));
                }
                else
                {
                    webBrowser.Refresh(WebBrowserRefreshOption.Completely);
                }
            }
            catch (System.UriFormatException)
            {
                return;
            }
            System.GC.Collect();
