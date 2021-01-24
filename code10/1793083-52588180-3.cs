    var credentials = GetCredentials(userName, password);
    var client = new ExcelClient(webUrl, credentials);
    var data = client.ReadTable("Shared Documents/Financial Sample.xlsx", "Sheet1","A1", "P500");
    JObject table = JObject.Parse(data);
    int idx = 0;
    foreach(var row in table["rows"])
    {
         if(idx == 0)
         {
            //skip header
         }
         else
         {
            //get cell values
            var segment = row[0]["v"] as JValue;
            var country = row[1]["v"] as JValue;
            Console.WriteLine("Segment: {0}, Country: {1}", segment.Value,country.Value);
         }
         idx++;
    }
