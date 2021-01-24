      using(var client = new HttpClient())
      {
       var res =  client.PostAsync("YOUR URL", new   StringContent(JSONConvert.serializeObject(new { 
    OBJECT DEF HERE }, Encoding.UTF8, "application/json"));
                    try
                    {
                        res.Result.EnsureSuccessStatusCode();
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
    }   
