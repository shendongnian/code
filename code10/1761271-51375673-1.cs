        /// <summary>
        /// Get Web Title By HttpClient
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetWebTitleByHttpClient(string url)
        {           
            HttpClient httpclient = new HttpClient();           
            var task = httpclient.GetAsync(url);
            task.Wait();
            HttpResponseMessage message = task.Result;
            Stream myResponseStream = message.Content.ReadAsStreamAsync().Result;
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            String result = myStreamReader.ReadToEnd();
            int startIndex = result.IndexOf("<title>") + 7;
            int endIndex = result.IndexOf("</title>");
            if (endIndex > startIndex)
            {
                string title = result.Substring(startIndex, endIndex - startIndex);
                return title;
            }
            else
            {
                return null;
            }
            
        }
