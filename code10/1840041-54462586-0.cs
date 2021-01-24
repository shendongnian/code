    var jobj = JsonConvert.DeserializeObject<JObject>(responseString);
    var jsString = jobj["return "].ToString(); //here you have to make sure that the key name is specified correctly.
    var token = JToken.Parse(jsString);
    //now determine wither the recieved string is an object or an array
    if (token is JArray)
    {
         var results = token.ToObject<List<JsonResult>>();
         dataGridView1b.DataSource = results;
    }
    else if (token is JObject)
    {
        var result = token.ToObject<JsonResult>();
        var results = new List<JsonResult>();
        results.Add(result);
        dataGridView1b.DataSource = results;
    }        
