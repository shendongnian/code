    HttpClient client = new HttpClient();
    var response =client.GetAsync("http://evolus.ddns.net/Q4Evolution/php/phpCategoria/BOPesquisa
        Emp.php").Result;
    if (response.IsSuccessStatusCode)
    {
       string output =response.Content.ReadAsStringAsync().Result;
       //obj is your desired c# object
       var obj =JsonConvert.DeserializeObject<RootObject>(output);
    }
