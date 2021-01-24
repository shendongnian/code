        var data = "[{ Description:\"METROBlueLine\",ProviderID:\"8\",Route:\"901\"},{Description:\"METRO Green Line\",ProviderID:\"8\",Route:\"902\"}]";
    
                    var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var mylist = ser.Deserialize<List<Dictionary<string,string>>>(data);
        //or JSON.net
                    var mylist = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    
                    var routes = mylist.SelectMany(a => a).Where(c => c.Key == "Route").ToList();
                    foreach (var route in routes)
                        Console.Write(route);
    
        output
        [Route, 901][Route, 902]
