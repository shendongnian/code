    public async Task<ActionResult> Index()
            {
                string apiUrl = "http://localhost:58764/api/Marketing/GetMarketing";
    
                using (HttpClient client=new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        EntityType entity = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityType>(data);
    
                    }
    
    
                }
                return View();
    
            }
