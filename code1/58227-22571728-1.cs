           try
            {
                if (webBrowser.Url.Equals("about:blank")) //first visit
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
            System.GC.Collect(); // may be omitted, Windows can do this automatically
