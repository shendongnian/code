    bool go = false;
    string SiteContent1 = string.Empty;
    string SiteContent2 = string.Empty;
    int index = 0;
    WebBrowser wb = new  WebBrowser();
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (go)
                {
                    SiteContent2 = wb.DocumentText;
                    // Code to compare to contents of the webbrowser
                    index++;
                    go = false;
                    steps = 1;
                }
                
                if (!go)
                    {
                       
                        if (index >= TotalSiteCount)
                        {
                            Stop();
                        }
                        else if (steps == 1)
                        {
                            wb.Navigate(UrltocompareList[index].Url1);
                            
                        }
                        else if (steps == 2)
                        {
                            SiteContent1 = wb.DocumentText;
                            wb.Navigate(UrltocompareList[index].Url2);
                            go = true;
                        }
                        steps++;                        
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        }
