    private void twitterCallback(IAsyncResult result)
    {
        HttpWebRequest request = (HttpWebRequest)result.AsyncState;
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
        TextReader reader = new StreamReader(response.GetResponseStream());
        string strResponse = reader.ReadToEnd();
        Console.WriteLine("I am done here");
        ////TwitterPost.Text = "hello there";
        postMyMessage(TwitterPost.Text);
    }
    private void postMyMessage(string text)
    {
        if (this.Dispatcher.CheckAccess())
            TwitterPost.Text = text;
        else
            this.Dispatcher.BeginInvoke(new Action<string>(postMyMessage), text);
    }
