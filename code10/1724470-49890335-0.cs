    public async Task<bool> GeneratePayment(string JsonData) {
        var principal = User as ClaimsPrincipal;
        Session["realmId"] = "XXXXXX";
        if (Session["realmId"] != null) {
            string realmId = Session["realmId"].ToString();
            string qboBaseUrl = ConfigurationManager.AppSettings["QBOBaseUrl"];
            //add qbobase url and query
            string uri = string.Format("{0}/v3/company/{1}/invoice", qboBaseUrl, realmId);
            try {
                var client = http.Value; //singleton http client
                var result = await client.PostAsync(uri, new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json"));
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        else
            return false;
    }    
    
    //Singleton lazy loaded HttpClieny
    static Lazy<HttpClient> http = new Lazy<HttpClient>(() => {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
        client.DefaultRequestHeaders.Add("ContentType", "application/json;charset=UTF-8");
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "XXXX");
        return client;
    });
