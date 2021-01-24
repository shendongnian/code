    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    //...code omitted for brevity
    var order = new Dictionary<string, string>();
    order["ResponseType"] = "JSON";
    order["Token"] = "P74kXRjM4W44l9qNw8u3";
    order["PaymentMode"] = "1";
    order["ProductDetails"] = JsonConvert.SerializeObject(ProductDetails);
    order["ShippingAddress"] = JsonConvert.SerializeObject(ShippingAdress);
    order["ClientDetails"] = JsonConvert.SerializeObject(ClientDetails);
    order["CurrencyAbbreviation"] = "JOD";
    var content = new FormUrlEncodedContent(order);
    var url = "https://bmswebservices.itmam.com/OrderingManagement/Orders.asmx/PlaceOrder";
    var response = await client.PostAsync(url, content);    
    if (!response.IsSuccessStatusCode) {
        Console.WriteLine("ERROR:  Products Not Posted." + response.ReasonPhrase);
        return null;
    }
    var cs = await response.Content.ReadAsAsync<Order>();
    return Json(cs); 
