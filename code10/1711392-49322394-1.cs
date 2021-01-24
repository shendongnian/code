     public static ApiResponse PutIn(string user, string password, 
                         string endpoint , string Httpcontent)
        {
            User = user;
            Password = password;
            Endpoint = endpoint;
            Content = NewtonSoft.Json.JsonConvert.DeserializeObject<Product>(Httpcontent);
            ExecutePUTRequest().Wait();
            return apiResponse;
        }
