        /// <summary>
		/// Executes an HTTP POST command and retrives the information.		
		/// This function will automatically include a "source" parameter if the "Source" property is set.
		/// </summary>
		/// <param name="url">The URL to perform the POST operation</param>
		/// <param name="userName">The username to use with the request</param>
		/// <param name="password">The password to use with the request</param>
		/// <param name="data">The data to post</param> 
		/// <returns>The response of the request, or null if we got 404 or nothing.</returns>
		protected string ExecutePostCommand(string url, string userName, string password, string data) {
			System.Net.ServicePointManager.Expect100Continue = false;
 
			WebRequest request = WebRequest.Create(url);
			if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password)) {
				request.Credentials = new NetworkCredential(userName, password);
				request.ContentType = "application/x-www-form-urlencoded";
				request.Method = "POST";
 
				if (!string.IsNullOrEmpty(TwitterClient)) {
					request.Headers.Add("X-Twitter-Client", TwitterClient);
				}
 
				if (!string.IsNullOrEmpty(TwitterClientVersion)) {
					request.Headers.Add("X-Twitter-Version", TwitterClientVersion);
				}
 
				if (!string.IsNullOrEmpty(TwitterClientUrl)) {
					request.Headers.Add("X-Twitter-URL", TwitterClientUrl);
				}
 
 
				if (!string.IsNullOrEmpty(Source)) {
					data += "&source=" + HttpUtility.UrlEncode(Source);
				}
 
				byte[] bytes = Encoding.UTF8.GetBytes(data);
 
				request.ContentLength = bytes.Length;
				using (Stream requestStream = request.GetRequestStream()) {
					requestStream.Write(bytes, 0, bytes.Length);
 
					using (WebResponse response = request.GetResponse()) {
						using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
							return reader.ReadToEnd();
						}
					}
				}
			}
 
			return null;
		}
