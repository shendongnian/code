    private void browser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
       //Cancel the request
       e.Cancel = true;
       using (WebClient client = new WebClient())
       {
           string html = client.DownloadString(e.Url.ToString());
           //Find the text that you want to replace here and replace it
           browser1.DocumentText = html;
       }
    }
