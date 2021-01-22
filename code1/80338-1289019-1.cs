    JsonArray jsonArray = (JsonArray)JsonArray.Load(e.Result);
    List<SomeObject> lst = new List<SomeObject>();
    foreach (System.Json.JsonObject obj in jsonArray)
    {
        SomeObject obj = new SomeObject();
        obj.ID = int.Parse(obj["ID"].ToString();
        obj.Description = obj["Description"].ToString();
        obj.Value = double.Parse(obj["Value"].ToString());
        lst.Add(obj);
    }
