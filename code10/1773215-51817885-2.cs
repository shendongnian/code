    string jsonString = "[{\"Project\":\"example\", \"Ref\":\"001BC50C70000A21\", \"Latitude\":43.643166, \"Longitude\":1.454769, \"ParkList\": [{\"Id\":\"001BC50C70000A21P1\", \"State\":1, \"DateTime\":\"2018-02-15T08:07:18.987Z\"}, {\"Id\":\"001BC50C70000A21P2\",\"State\":1,\"DateTime\":\"2018-02-15T08:11:41.824Z\"}]}]";
    			
    //You used [square brackets] at first, so we need to deserialize with list
    List<KMessage> kMsg = JsonConvert.DeserializeObject<List<KMessage>>(jsonString);
    foreach (Parklist item in kMsg[0].ParkList)
         {
             Console.WriteLine("Id: " + item.Id + " State: " + item.State + " DateTime: " + item.DateTime);
         }
----------
    Output:
    
    Id: 001BC50C70000A21P1 State: 1 DateTime: 2/15/2018 8:07:18 AM
    Id: 001BC50C70000A21P2 State: 1 DateTime: 2/15/2018 8:11:41 AM
