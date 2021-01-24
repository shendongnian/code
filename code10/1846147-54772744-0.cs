    using System.Net;
    using System.Collections.Specialized;
    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;  // TLS v1.2 only
    var client = new WebClient()
    {
        // Credentials = new NetworkCredential("user", "app_password"), // Take this line out
        BaseAddress = "https://api.bitbucket.org",
    };
    client.Headers[HttpRequestHeader.Authorization] =
        "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("user:app_password"));
    client.DownloadString(
        "/2.0/repositories/friendly_private_account/repo");             // Now it works
