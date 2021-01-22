        public void Test()
        {
            Uri result = UrlIsValid("www.google.com");
            if (result == null)
            {
                //Invalid Url format
            }
            else
            {
                if (UrlExists(result))
                {
                    //Url is valid and exists
                }
                else
                {
                    //Url is valid but the site doesn't exist
                }
            }
            Console.ReadLine();
        }
        private static Uri UrlIsValid(string testUrl)
        {
            try
            {
                if (!(testUrl.StartsWith(@"http://") || testUrl.StartsWith(@"http://")))
                {
                    testUrl = @"http://" + testUrl;
                }
                return new Uri(testUrl);
            }
            catch (UriFormatException)
            {
                return null;
            }   
        }
        private static bool UrlExists(Uri validUri)
        {
            try
            {   
                WebRequest.Create(validUri).GetResponse();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
