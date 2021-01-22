            public static string GET(string URL)
        {
            string JSON;
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            HttpRequestCachePolicy cPolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
            request.Accept = "application/json";
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.CachePolicy = cPolicy;
            request.Pipelined = false;
            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //From http://www.west-wind.com/WebLog/posts/102969.aspx
                Stream responseStream = responseStream = response.GetResponseStream();
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                // Get the response stream  
                StreamReader readerF = new StreamReader(responseStream);
                JSON = readerF.ReadToEnd();
            }
            return JSON;
        }
