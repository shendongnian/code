            var proxy = WebRequest.GetSystemWebProxy();
            Uri testUrl = new Uri("http://proxy.example.com");
            proxyUrl = proxy.GetProxy(testUrl);
            if (proxyUrl != testUrl)
                //Use your proxy here
            else
                //We are not using a proxy
