    [SharePointContextWebAPIFilter]
    [HttpGet]
    [ActionName("InviaMailAlProtocollo")]
    public async Task<IHttpActionResult> InviaMailAlProtocollo(string siglaIdUor) {
        Console.WriteLine("INTO InviaAlProtocollo()" + siglaIdUor);
        // Ignore self signed certificate of the called API:
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        string requestUri = urlBaseProtocolloApi + "/api/XXX/InviaAlProtocollo/" + siglaIdUor;
        // Setting my credentials:
        credCache.Add(new Uri(requestUri), "NTLM", myCreds);
        var handler = new HttpClientHandler {
            UseDefaultCredentials = true,
            Credentials = credCache
        };
        var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Add("UserAgent", "Mozilla/4.0+(compatible;+MSIE+5.01;+Windows+NT+5.0");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json;odata=verbose"));
        // Create the MailBuffer object that have to be passed to the API into the request body:
        var buffer = new MailBuffer() {
            Nome = "blablabla",
            Buffer = Encoding.UTF8.GetBytes("TEST")
        };
        //convert model to JSON using Json.Net
        var jsonPayload = JsonConvert.SerializeObject(buffer);
        var mailContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        // Obtain the response from the API:
        var response = await client.PostAsync(requestUri, mailContent);
        if (response.IsSuccessStatusCode) {
            var jarray = await response.Content.ReadAsAsync<JArray>();
            Console.WriteLine(jarray);
            return Ok(jArray);
        }
        return BadRequest();
    }
