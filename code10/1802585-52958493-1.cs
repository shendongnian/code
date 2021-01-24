            var msg = new HttpRequestMessage(HttpMethod.Post, url);
            var login = new LoginModel() { username = "test", password = "test" }; 
    
            msg.Content = new ObjectContent<LoginModel>(login, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue)null);
            
            try 
            {
                //Debugger exits after calling this line.
                var result = await WebApiApplication.HttpClientInstance.SendAsync(msg); 
                 //Debugger never gets here. 
                 if (result.IsSuccessStatusCode)
                 {
                    var response = await result.Content.ReadAsStringAsync(); 
                 }
            }
            catch (Exception ex)
            {
                // do something with the ex.Message;
            }
    
           
