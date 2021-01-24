    try
    {
        var content = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8,"application/json");
       var response=await this.client.PostAsync("http://localhost:8500/mat",
                              content);
        string str=await response.Content.ReadAsStringAsync();
        stringdata = JsonConvert.DeserializeObject<string>(str);
        return data;     
    }
    catch (Exception ex)
    {
        Console.WriteLine("Threw in client" + ex.Message);
        throw;
    }
}
