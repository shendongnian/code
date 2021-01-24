    // Use this if you are in a web context
    // var certificatePath = System.Web.HttpContext.Current.Server.MapPath(
    //                  "your_client_certificate_path"),
    // Use this in a non web context. 
    // certificatePath should be the same value as the parameter you are using 
    // in your command line
    //  -cert mycert.cert   <------ This one
    var certificatePath = "your_physical_path_file_to_mycert.cert";
    // Certificate from file 
    var _clientCertificate = new X509Certificate2(
                              certificatePath,
                              "your_client_certificate_key");
    // Web handler
    var handler = new System.Net.Http.WebRequestHandler();
    handler.ClientCertificates.Add(_clientCertificate);
    // Http Client
    var _httpClient = new System.Net.Http.HttpClient(handler);
    _httpClient.DefaultRequestHeaders.Add("Header Key", "Header Value");
    // Requests
    _httpClient.GetAsync("your_request_URI");
