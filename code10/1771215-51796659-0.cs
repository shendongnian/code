    public sealed partial class MainPage : Page
    {
        String contactLink = "";
        String authToken = "";
        String authUser = "";
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void IcloudBtn_Click(object sender, RoutedEventArgs e)
        {
            HttpResponseHeaderCollection respHeaders = await ContactApple();
            ContactsBlock.Text += "CONTACT LINK: " + contactLink + "\n";
            ContactsBlock.Text += authToken + "\n";
            ContactsBlock.Text += authUser + "\n";
        }
        private async void GetToken_Click(object sender, RoutedEventArgs e)
        {
            HttpResponseHeaderCollection respHeaders = await ContactApple(AuthenticationCode.Text);
            ContactsBlock.Text += "CONTACT LINK: " + contactLink + "\n";
            ContactsBlock.Text += authToken + "\n";
            ContactsBlock.Text += authUser + "\n";
        }
        private async void GetContacts_Click(object sender, RoutedEventArgs e)
        {
            Uri contactUri = new Uri(contactLink + "/co/startup?locale=en_US&order=last%2Cfirst");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Origin", "https://www.icloud.com");
            client.DefaultRequestHeaders.Add("Cookie", authToken + ";" + authUser + ";");
            HttpResponseMessage hrm = await client.GetAsync(contactUri);
            JObject contactJson = JObject.Parse(await hrm.Content.ReadAsStringAsync());
            ContactsBlock.Text += contactJson["contacts"];
        }
        private async Task<HttpResponseHeaderCollection> ContactApple(String authentication = "")
        {
            // The apple id and the password
            String appleId = "AppleID";
            String password = "Password" + authentication;
            // https://stackoverflow.com/questions/31457068/get-icloud-contact-list-in-c-sharp?noredirect=1&lq=1
            // Post request will have this in the content
            String data = "{\"apple_id\":" + appleId + ", \"password\":" + password + ", \"extended_login\":true}";
            HttpStringContent content = new HttpStringContent(data, UnicodeEncoding.Utf8);
            // The URI to get the tokens from:
            Uri requestUri = new Uri("https://setup.icloud.com/setup/ws/1/accountLogin");
            // Create an instance of the HttpClient (Windows.Web.Http)
            HttpClient client = new HttpClient();
            // Add Origin = https://www.icloud.com in the header.
            client.DefaultRequestHeaders.Add("Origin", "https://www.icloud.com");
            // Post request and read response as JSON object (NewtonSoft)
            HttpResponseMessage hrm = await client.PostAsync(requestUri, content);
            JObject resp = JObject.Parse(await hrm.Content.ReadAsStringAsync());
            // Get the URL to the contacts
            contactLink = (String)resp["webservices"]["contacts"]["url"];
            // Read the headers for AUTH-TOKEN and AUTH-USER Cookies,
            HttpResponseHeaderCollection headers = hrm.Headers;
            if (headers.ContainsKey("Set-Cookie"))
            {
                String cookie = headers["Set-Cookie"];
                char[] separators = { ';', ',' };
                String[] tokens = cookie.Split(separators);
                foreach (String token in tokens)
                {
                    int length = token.Length;
                    if (token.Contains("X-APPLE-WEBAUTH-TOKEN"))
                    {
                        authToken = token;
                    }
                    if (token.Contains("X-APPLE-WEBAUTH-USER"))
                    {
                        authUser = token;
                    }
                }
            }
            return headers;
        }
    }
