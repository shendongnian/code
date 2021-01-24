    // reading lines in loop
    foreach (var line in System.IO.File.ReadLines(filePath))
    {
        // Parse the line into the array
        JArray jsonArray = Newtonsoft.Json.Linq.JArray.Parse(line);
        //parse the array into object, 
        //since each line has one object I have hardcoded the index to 0
        //if there can be more objects in one array then will need to iterate
        var json = JObject.Parse(jsonArray[0].ToString());
        // access the token
        var title = json["sym"]; // or json.SelectToken("sym");
        Console.WriteLine(title.First());
    }
