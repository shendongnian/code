        /// <summary>Gets a cookie value from cookies for given key.</summary>
        /// <param name="cookieKey">The key for the cookie value we require.</param>
        /// <returns>The cookie value.</returns>
        /// <exception cref="KeyNotFoundException">If the key was not found.</exception>
        private string GetCookieValue(string cookieKey)
        {
            string cookieHeader = WebOperationContext.Current.IncomingRequest.Headers[HttpRequestHeader.Cookie];
            string[] cookies = cookieHeader.Split(';');
            string result = string.Empty;
            bool cookieFound = false;
            foreach (string currentCookie in cookies)
            {
                string cookie = currentCookie.Trim();
                // Split the key/values out for each cookie.
                string[] cookieKeyValue = cookie.Split('=');
                // Compare the keys
                if (cookieKeyValue[0] == cookieKey)
                {
                    result = cookieKeyValue[1];
                    cookieFound = true;
                    break;
                }
            }
            if (!cookieFound)
            {                
                string msg = string.Format("Unable to find cookie value for cookie key '{0}'", cookieKey);
                throw new KeyNotFoundException(msg);
            }
            // Note: The result may still be empty if there wasn't a value set for the cookie.
            // e.g. 'key=' rather than 'key=123'
            return result;
        }        
        /// <summary>Sets the cookie header.</summary>
        /// <param name="cookie">The cookie value to set.</param>
        private void SetCookie(string cookie)
        {
            // Set the cookie for all paths.
            cookie = cookie + "; path=/;" ;
            string currentHeaderValue = WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie];
            if (!string.IsNullOrEmpty(currentHeaderValue))
            {
                WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie]
                    = currentHeaderValue + "\r\n" + cookie;
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.SetCookie] = cookie;
            }
        }
