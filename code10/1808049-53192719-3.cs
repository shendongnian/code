    public class TrustedAuth
    {
        public async Task<string> requestTicket(int sso, string server, string site)
        {
            try
            {
                //Assign parameters and values
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("username", sso.ToString()));
                values.Add(new KeyValuePair<string, string>("target_site", site));
                //Web Application is HTTP and Tableau is HTTPS, there are certification issues. I need to fake the certs out and return them as true.
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                //Instantiate HttpClient class
                var client = new HttpClient();
                //Encode Content
                var req = new HttpRequestMessage(HttpMethod.Post, server) { Content = new FormUrlEncodedContent(values) };
                //POST request
                var res = await client.SendAsync(req);
                //Get response value
                var responseString = await res.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(@"c:\inetpub\wwwroot\WebApplication\TrustedAuthError.txt", ":::ERROR::: " + System.DateTime.Today.ToString() + ":::" + e.ToString() + Environment.NewLine);
                //Add Log4Net logging
            }
            return "-1";
        }
        public string addTicket(string ticket, string reportLink)
        {
            //Add ticket parameter with ticket value. I'm using </object> as my keyword to find and replace
            string addedTicket = reportLink.Replace("</object>", "<param name='ticket' value='" + ticket + "' /></object>");
            return addedTicket;
        }
    }
