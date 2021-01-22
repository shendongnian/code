    private void button7_Click(object sender, RoutedEventArgs e)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.BeginGetResponse(ReqCallback, httpWebRequest);
    }
    
    private void ReqCallback(IAsyncResult asyncResult)
    {
      using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.EndGetResponse(asyncResult))
      {
        XDocument x = XDocument.Load(httpWebResponse.GetResponseStream());
        Dispatcher.BeginInvoke((Action) () => ShowGuildies(x));
      }
    }
