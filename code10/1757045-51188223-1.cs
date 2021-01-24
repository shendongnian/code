    if(response.IsSuccessStatusCode) {
        ViewBag.Msg = "Success";
        var json = await response.Content.ReadAsStringAsync();
        var jObject = JObject.Parse(json);
        if (jObject.ContainsKey("items"))
            logs = jObject["items"].ToObject<List<EmailLog>>();   
    }
