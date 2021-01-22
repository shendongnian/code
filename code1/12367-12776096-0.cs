    public void GetResponseAsync (HttpWebRequest request, Action<HttpWebResponse> gotResponse)
		{
			if (request != null) { 
				request.BeginGetRequestStream ((r) => {
					try { // there's a try/catch here because execution path is different from invokation one, exception here may cause a crash
						HttpWebResponse response = request.EndGetResponse (r);
						if (gotResponse != null) 
							gotResponse (response);
					} catch (Exception x) {
						Console.WriteLine ("Unable to get response for '" + request.RequestUri + "' Err: " + x);
					}
				}, null);
			} 
		}
