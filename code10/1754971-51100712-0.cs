    string resp; //this is where you will store your response from server
    JArray array;
    JObject json;
    if(resp == "<Empty JSON content>")
    {
       Console.WriteLine("Response is empty json");
    }
    else
    {
       try
      {
        array = JArray.Parse(resp);
        Console.WriteLine("Array parsed");
      }
      catch (Newtonsoft.Json.JsonException ex)
      {
          try
          {
             json = JObject.Parse(resp);
             Console.WriteLine("error parsed");
          }
          catch(Newtonsoft.Json.JsonException ex2)
          {
             Console.WriteLine("Response was not json object");
          }        
      }
    }
