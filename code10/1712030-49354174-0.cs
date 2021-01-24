    //...
    
    var response = await client.PostAsJsonAsync("api/v1/auth", credentials);
    if(response.IsSuccessStatusCode) { // If 200 OK
        //parse response body to desired
        var user = await response.Content.ReadAsAsync<User>();
        return user;
    } else {
        //Not 200. You could also consider checking for if status code is 400
        var message = await response.Content.ReadAsStringAsync();
        //Do something with message like
        //throw new Exception(message);
    }
    
    //...
