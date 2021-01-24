    public static ApiClient GetDocuSignClient()
    {
        string accountType = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".DocuSignAccountType");
        string integratorKey = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".DocuSignIntegratorKey");
        string userID = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".DocuSignUserID");
        string rsaPrivate = SettingsKeyInfoProvider.GetValue(SiteContext.CurrentSiteName + ".DocuSignRSAKey");
        string basePath = accountType == "sandbox" ? "account-d.docusign.com" : "account.docusign.com";
        // this gets replaced when we communicate with the api
        string clientBasePath = accountType == "sandbox" ? "https://demo.docusign.net/restapi" : "https://www.docusign.net/restapi";
        int expirationHours = 1;
        if (accountType == "" || integratorKey == "" || userID == "" || rsaPrivate == "")
            throw new System.Configuration.ConfigurationErrorsException("All DocuSign settings must be set in Settings->Integration->DocuSign");
        ApiClient dsClient = new ApiClient(clientBasePath);
        dsClient.ConfigureJwtAuthorizationFlow(integratorKey, userID, basePath, HttpContext.Current.Server.MapPath(rsaPrivate), expirationHours);
        
        var rsUserClient = new RestSharp.RestClient("https://" + basePath); ;
        RestSharp.RestRequest acctReq = new RestSharp.RestRequest();
        acctReq.Method = RestSharp.Method.GET;
        acctReq.RequestFormat = RestSharp.DataFormat.Json;
        acctReq.Resource = "oauth/userinfo";
        // even though we're not using the SDK to get accounts, we can use the token it generates
        AuthenticationApi authClient = new AuthenticationApi(dsClient.Configuration);
        acctReq.AddHeader("Authorization", authClient.Configuration.DefaultHeader["Authorization"]);
        RestSharp.IRestResponse rsResponse = rsUserClient.Execute(acctReq);
        if (rsResponse.ResponseStatus != RestSharp.ResponseStatus.Completed || rsResponse.StatusCode != HttpStatusCode.OK)
        {
            if (rsResponse.ErrorException != null)
                throw new WebException("DocuSign login failed: " + rsResponse.ErrorException.Message, rsResponse.ErrorException);
            else if (rsResponse.StatusCode == HttpStatusCode.BadRequest)
                throw new WebException(String.Format("DocuSign login failed. StatusCode: {0} <br/>ErrorDescription: {1}", rsResponse.StatusCode, rsResponse.Content));
            else
                throw new WebException(String.Format("DocuSign login failed. StatusCode: {0} ResponseStatus: {1}", rsResponse.StatusCode, rsResponse.ResponseStatus));
        }
        DocuSignLoginInfo loginInfo = JsonConvert.DeserializeObject<DocuSignLoginInfo>(rsResponse.Content);
        DocuSignLoginAccount toUse = null;
        foreach (var loginAcct in loginInfo.Accounts)
        {
            if (toUse == null)
            {
                toUse = loginAcct; // use first account
            }
            else if (loginAcct.IsDefault && 
                ((accountType == "sandbox" && loginAcct.Base_Uri.Contains("demo.")) || 
                (accountType != "sandbox" && !loginAcct.Base_Uri.Contains("demo."))))
            {
                toUse = loginAcct; // use default account if appropriate
            }
        }
        if (toUse == null)
        {
            throw new WebException("DocuSign login failed: " + loginInfo.Email + " doesn't have a login account we can use.");
        }
        else
        {
            SettingsKeyInfoProvider.SetValue("DocuSignAccountID", SiteContext.CurrentSiteName, toUse.Account_Id);
            string[] separatingStrings = { "/v2" };
            string restUrl = toUse.Base_Uri.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries)[0];
            if (!restUrl.Contains("/restapi"))
                restUrl += "/restapi";
            // Update ApiClient with the new base url from login call
            dsClient = new ApiClient(restUrl);
        }
        return dsClient;
    }
    public class DocuSignLoginAccount
    {
        public string Account_Id;
        public string Account_Name;
        public bool IsDefault;
        public string Base_Uri;
    }
    public class EnvelopeBrief
    {
        public string EnvID;
        public Signer CurrentSigner;
        public string ClientUserID;
    }
