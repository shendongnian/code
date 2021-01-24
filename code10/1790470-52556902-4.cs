    var url = "https://" + InterfaceAddress.Text + "/oauth/token";
    string username = UserName.Text;
    string password =  Password.Password;
    var form_params = new Dictionary<string,string>(){
        {"grant_type", "password"},
        {"username", username},
        {"password", password},
        {"client_id","4"},
        {"client_secret", "YAYLOOKATTHISNOTWORKING"},
        {"scope", ""}
    };
    var content = new FormUrlEncodedContent(form_params);    
    var response = await App.client.PostAsync(url, content);
    response.EnsureSuccessStatusCode();    // Throw if not a success code.
