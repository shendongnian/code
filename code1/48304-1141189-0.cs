        private static void SetProxy(HttpWebRequest request)
        {
            if (AppConstants.UseProxyCredentials)
            {
                //request.Proxy = available in System.Net configuration settings
                request.Proxy.Credentials = Credentials.GetProxyCredentials();
            }
            else
            {
                request.Proxy = null;
                //request.Proxy.Credentials = n/a
            }
        }
