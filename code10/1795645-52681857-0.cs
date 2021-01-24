    		string url = "https://www.isbnsearch.org/";
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage response = client.GetAsync(url).Result)
				{
					using (HttpContent content = response.Content)
					{
						string result = content.ReadAsStringAsync().Result;
						MessageBox.Show(result);
					}
				}
			}
