    var restClient = new RestClient(model.ApiUrl);
    var restRequest = new RestRequest("api/auth/createuser", Method.POST);
    restRequest.RequestFormat = DataFormat.Json;
    restRequest.AddBody(new {
                                FullName = model.FullName,
                                Email = model.Email,
                                Username = model.UserName,
                                Password = model.Password
                            });
    var restResponse = restClient.Execute(restRequest);
