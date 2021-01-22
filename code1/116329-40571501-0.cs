		public bool IsUrlExist(string url, int timeOutMs = 1000)
		{
			WebRequest webRequest = WebRequest.Create(url);
			webRequest.Method = "HEAD";
			webRequest.Timeout = timeOut;
			
			try
			{
				var response = webRequest.GetResponse();
				/* response is `200 OK` */
				response.Close();
			}
			catch
			{
				/* Any other response */
				return false;
			}
			return true;
		}
