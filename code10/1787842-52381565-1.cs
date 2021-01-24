    public static DataTable jsonStringToTable(string jsonContent)
    {
      dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonContent);
      DataTable dt = JsonConvert.DeserializeObject<DataTable>(Convert.ToString(jsonObject.Orders));
      return dt;
     }
