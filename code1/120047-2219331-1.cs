    		public bool IsAlive(string hostnameOrAddress)
		{
			bool alive = false;
			try
			{
				Uri address = new Uri(hostnameOrAddress);
				HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(address);
				request.Timeout = 5000;
				using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
				{
					alive = DoesResponseStatusCodeIndicateOnlineStatus(response);
				}
			}
			catch (WebException wex)
			{
				alive = DoesWebExceptionStatusIndicateOnlineStatus(wex);
			}
			return alive;
		}
