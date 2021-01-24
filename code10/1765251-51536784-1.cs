     string dataObjects = response.Content.ReadAsStringAsync().Result;  
     //Make sure to add a reference to System.Net.Http.Formatting.dll
     Console.WriteLine("Status : {0}\nReason : ({1})",
                            (int)response.StatusCode, response.StatusCode);
    Console.WriteLine("Data from server :\n"+dataObjects);
    dynamic json;
    if(dataObjects[0]!='[')
    {
        json = JValue.Parse("["+dataObjects+"]"); 
    }
    else
    {
        json = JValue.Parse(dataObjects);
    }
                    
    Console.WriteLine("\nData extracted by parsing in JSON format");
    Console.WriteLine(json.Count);
    for(int i = 0; i<json.Count;i++)
    {
        Console.WriteLine("\n"+(i+1)+".");
        Console.WriteLine("name :"+json[i].name);
        Console.WriteLine("uri :"+json[i].uri);
    }
