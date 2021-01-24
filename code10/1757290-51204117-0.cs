      public static async Task<List<BranchMasterModel>> GetBranchList(int city)
        {
            var client = new HttpClient(new NativeMessageHandler());
            client.BaseAddress = new Uri(UrlAdd);//("http://192.168.101.119:8475/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Convert.ToString(Application.Current.Properties["TokenTemp"]));
            var result = await client.GetAsync("api/Master/V2/Branch/"+city);
            string branch = await result.Content.ReadAsStringAsync();
            var branches = JsonConvert.DeserializeObject<List<BranchMasterModel>>(branch);
            return branches;
        }
