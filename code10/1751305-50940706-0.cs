    Uri postURL = new Uri(Constants.RestUrl + "/NewReservation");
    HttpClient client = new HttpClient();
    TimeSpan timeout = new TimeSpan(0, 0, 20);
    client.Timeout = timeout;                   
    var UserData = AccountCheck.CurrentUserData();
	JObject RequestData = new JObject(
		new JProperty("apiKey", UserData.ApiKey),
		new JProperty("customerID", UserData.CustomerId.ToString()),
		new JProperty("containerIDs", NewReservationRequest.ContainerIDs),
		new JProperty("containersQuantities", NewReservationRequest.ContainerQuantities),
		new JProperty("location", NewReservationRequest.Location),
		new JProperty("image", NewReservationRequest.ImageBlob),
        new JProperty("dateFrom", NewReservationRequest.StartDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)),
        new JProperty("dateTo", NewReservationRequest.StartDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)),
		new JProperty("expectedTime",NewReservationRequest.ExpectedTime),
		new JProperty("remarks", UserRemarks)
                    );
	var RequestDataString = new StringContent(RequestData.ToString(), Encoding.UTF8, "application/json");
	HttpResponseMessage responsePost = await client.PostAsync(postURL, RequestDataString);
    string response = await responsePost.Content.ReadAsStringAsync();
