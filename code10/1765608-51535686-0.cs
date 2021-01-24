    public static async Task<UserData> GetUserAuth(UserAuth userauth)
        {
            bool asd= CheckNetWorkStatus().Result;
            if (asd)
            {
                var client = new HttpClient(new NativeMessageHandler());
                client.BaseAddress = new Uri(UrlAdd);// ("http://192.168.101.119:8475/");
                var postData = new List<KeyValuePair<string, string>>();
                var dto = new UserAuth { grant_type = userauth.grant_type, password = userauth.password, username = userauth.username };
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("grant_type", userauth.grant_type));
                nvc.Add(new KeyValuePair<string, string>("password", userauth.password));
                nvc.Add(new KeyValuePair<string, string>("username", userauth.username));
                var req = new HttpRequestMessage(HttpMethod.Post, UrlAdd + "token") { Content = new FormUrlEncodedContent(nvc) };
                var res = await client.SendAsync(req);
                if (res.IsSuccessStatusCode)
                {
                    string result = await res.Content.ReadAsStringAsync();
                    var userData = JsonConvert.DeserializeObject<UserData>(result);
                    userData.ErrorMessage = "true";
                    return userData;
                }
                else
                {
                    UserData ud = new UserData();
                    ud.ErrorMessage = "Incorrect Password";
                    return ud;
                }
            }
            else
            {
                UserData ud = new UserData();
                ud.ErrorMessage = "Check Ur Connectivity";
                return ud;
            }
        }
