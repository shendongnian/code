     private UsersTB getuserDateByUserNameApi(string username, int userTypeId, string token)
        {
       string baseUri ="Url address of python application";
           try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseUri);//baseUri
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //httpClient.Timeout = TimeSpan.FromSeconds(30.0);
                    var response = httpClient.GetStringAsync(string.Format("api/client/getuserDateByUsername/{0}/{1}/{2}", username, userTypeId, WebSiteID)).Result;
                    return JsonConvert.DeserializeObject<UsersTB>(response.ToString());
                }
            }
            catch (Exception exp)
            {
                return null;
            }
        }  //api get
