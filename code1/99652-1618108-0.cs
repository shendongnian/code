        private static string GetUrl(string url)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ServerException("Server returned an error code (" + ((int)response.StatusCode).ToString() +
                    ") while trying to retrieve a new key: " + response.StatusDescription);
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
