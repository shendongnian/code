     var response = client.GetAsync(client.BaseAddress + "user?=" + ConfigurationManager.AppSettings["TestUserID"]).Result;
     if (response.IsSuccessStatusCode) 
     {
         var responseString = response.Content.ReadAsStringAsync().Result;
         user u = JsonConvert.DeserializeObject<user>(responseString);
    }
