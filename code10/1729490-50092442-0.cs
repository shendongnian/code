    public class BaseModel
    {
        ///
    }
    public class RecordStore
    {
       protected static List<BaseModel> Models;
    
       public static void PushItem<T>(T item)
          where T : BaseModel
       {
          var modelType = typeof(T);
          Console.WriteLine("pushing ModelType: " + modelType.ToString());
          Models.Add(item);
       }
    }
    
    public class Store
    {
       public static T FindRecord<T>(int id)
          where T : BaseModel
       {
          var modelType = typeof(T);
          var rClient = new RestClient();
          Debug.WriteLine($"making request to: {modelType.Name.ToLower()}/{id}");
          var response = rClient.makeRequest($"{modelType.Name.ToLower()}/{id}");
          var payload = JObject.Parse(response);
    
          var model = JsonConvert.DeserializeObject<T>(
             payload[modelType.Name.ToLower()]
               .ToString());
    
          RecordStore.PushItem(model);
    
          return model;
       }
    }
