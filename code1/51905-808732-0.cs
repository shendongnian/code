    public class CrawlUriTool
    {
        private Regex regex;
        private int pendingRequests;
        private List<Uri> uriCollection;
        private object uriCollectionSync = new object();
        private ManualResetEvent crawlCompletedEvent;
        public List<Uri> CrawlUri(Uri uri)
        {
            this.pendingRequests = 0;
            this.uriCollection = new List<Uri>();
            this.crawlCompletedEvent = new ManualResetEvent(false);
            this.StartUriCrawl(uri);
            this.crawlCompletedEvent.WaitOne();
            return this.uriCollection;
        }
        private void StartUriCrawl(Uri uri)
        {
            Interlocked.Increment(ref this.pendingRequests);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.BeginGetResponse(this.UriCrawlCallback, request);
        }
        private void UriCrawlCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                string responseText = this.GetTextFromResponse(response); // not included
                foreach (Match match in this.regex.Matches(responseText))
                {
                    Uri newUri = new Uri(response.ResponseUri, match.Value);
                    lock (this.uriCollectionSync)
                    {
                        if (!this.uriCollection.Contains(newUri))
                        {
                            this.uriCollection.Add(newUri);
                            this.StartUriCrawl(newUri);
                        }
                    }
                }
            }
            catch (WebException exception)
            {
                // handle exception
            }
            finally
            {
                if (Interlocked.Decrement(ref this.pendingRequests) == 0)
                {
                    this.crawlCompletedEvent.Set();
                }
            }
        }
    }
