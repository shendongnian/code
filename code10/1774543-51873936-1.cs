    HttpResponseMessage response = null;
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Post, url+"/api/Transaction/SendTransaction"))
                    {
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", System.Web.HttpContext.Current.Session["WebApiAccessToken"].ToString());
                        var data = new StringContent(JsonConvert.SerializeObject(finale, Encoding.UTF8, "application/json"));
    request.Content = data;
                        response = await client.SendAsync(request);
                    }
                }
