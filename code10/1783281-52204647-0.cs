    :
        var companies = db.Companies.ToList(); //supposing db is you DbContext on EF
        var myTypesFromApi = new List<MyTypeT>();
        companies.ForEach(async company =>
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetStringAsync("http://myapi.com/v1/");
                    myTypesFromApi.Add(JsonConvert.DeserializeObject<MyTypeT>(res));
                }
            }
            catch (Exception e)
            {
                //catch properly your exception here
            }
        });
