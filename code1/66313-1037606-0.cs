        /// <summary>
        /// Submits a request to the specified url and returns the text response, or string.Empty if the request failed.
        /// </summary>
        /// <param name="uri">The url to submit the request to.</param>
        /// <returns>The text response from the specified url, or string.Empty if the request failed.</returns>
        protected string getPageResponse(string url)
        {
            //set the default result
            string responseText = string.Empty;
    
            //create a request targetting the url
            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(url);
            //set the credentials of the request
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
             
            //get the response from the request
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            //get the response code (format it as a decimal)
            string statusCode = response.StatusCode.ToString("d");
    
            //only continue if we had a succesful response (2XX or 3XX)
            if (statusCode.StartsWith("2") || statusCode.StartsWith("3"))
            {
                //get the response stream so we can read it
                Stream responseStream = response.GetResponseStream();
                //create a stream reader to read the response
                StreamReader responseReader = new StreamReader(responseStream);
                //read the response text (this should be javascript)
                responseText = responseReader.ReadToEnd();
            }
    
            //return the response text of the request
            return responseText;
        }
