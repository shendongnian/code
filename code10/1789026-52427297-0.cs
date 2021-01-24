            var httpWebRequest = WebRequest.Create(url);
			httpWebRequest.Method = "DELETE";
			httpWebRequest.ContentType = "application/json";
			using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
			using (var stream = response.GetResponseStream())
			using (var reader = new StreamReader(stream))
			{
				return (reader.ReadToEnd(), response.StatusCode);
			}
