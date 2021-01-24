    using (WebClient client = new WebClient())
            {
                try
                {
                     string htmlCode = client.DownloadString("http://isbnsearch.org/isbn/");
                     MessageBox.Show(htmlCode);
                }
                catch (Exception e)
                { 
                     MessageBox.Show(e.Message);
                }
            }
