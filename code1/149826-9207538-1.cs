    public String Post(String url, IDictionary<String, String> data)
		{
			String requestData = String.Join("&", data.Select(x => String.Format("{0}={1}", HttpUtility.UrlEncode(x.Key), HttpUtility.UrlEncode(x.Value))));
			Byte[] requestBytes = Encoding.UTF8.GetBytes(requestData);
			CookieContainer cookies = new CookieContainer();
			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
			request.CookieContainer = cookies;
			request.Method = WebRequestMethods.Http.Post;
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = requestBytes.Length;
			request.AllowAutoRedirect = false;
			
			Stream requestStream = request.GetRequestStream();
			requestStream.Write(requestBytes, 0, requestBytes.Length);
			requestStream.Close();
			HttpWebResponse response = request.GetResponse() as HttpWebResponse;
			while (response.StatusCode == HttpStatusCode.Found)
			{
				response.Close();
				String location = response.Headers[HttpResponseHeader.Location];
				request = WebRequest.Create(location) as HttpWebRequest;
				request.CookieContainer = cookies;
				request.Method = WebRequestMethods.Http.Get;
				response = request.GetResponse() as HttpWebResponse;
			}
			String responseData = this.Read(response.GetResponseStream());
			response.Close();
			return (responseData);
		}
