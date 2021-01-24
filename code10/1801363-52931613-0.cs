            // Certificate from file 
            var _clientCertificate = new X509Certificate2(
                          System.Web.HttpContext.Current.Server.MapPath(
                              "your_client_certificate_path"), 
                          "your_client_certificate_key");
            // Web handler
            WebRequestHandler handler = new WebRequestHandler();
            handler.ClientCertificates.Add(_clientCertificate);
            // Http Client
            var _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Add("Header Key", "Header Value");
            // Requests
            _httpClient.GetAsync("your_request_URI");
