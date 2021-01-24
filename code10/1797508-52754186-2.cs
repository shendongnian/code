    class Program
    {
        static void Main(string[] args)
        {
            //This is your input json string
            var inputJson = @"{
                          'datamapItems': [
                                       {
                                          'paramName': 'VE8321C',
                                          'datamapKey': {
                                                       'module': 1,
                                                       'id': 1391
                                          },
                                          'min': '0',
                                          'max': '40',
                                          'default': 222,
                                          'rateHz': 0,
                                          'timeoutMs': 0,
                                          'dataType': 'uint16'
                                        }
                                     ]
                               }";
            var result = JsonConvert.DeserializeObject<Datamap>(inputJson);  //Here you can deserialize your json
            DatamapKey datamapKey = new DatamapKey();
            datamapKey._DatamapKeys = new Dictionary<string, JToken>();
            datamapKey._DatamapKeys.Add("module", 1);
            datamapKey._DatamapKeys.Add("id", 1391);
            datamapKey._DatamapKeys.Add("ABC", 123);   //Here I added extra key/value pair to your inner object
            DatamapItem datamapItem = new DatamapItem();
            datamapItem._DatamapItems = new Dictionary<string, JToken>();
            datamapItem._DatamapItems.Add("paramName", "VE8321C");
            datamapItem._DatamapItems.Add("datamapKey", JToken.FromObject(datamapKey));
            datamapItem._DatamapItems.Add("min", "0");
            datamapItem._DatamapItems.Add("max", "40");
            datamapItem._DatamapItems.Add("default", 222);
            datamapItem._DatamapItems.Add("rateHz", 0);
            datamapItem._DatamapItems.Add("timeoutMs", 0);
            datamapItem._DatamapItems.Add("dataType", "uint16");
            datamapItem._DatamapItems.Add("PQR", "123");   //Here I added extra key/value pair to your outer object
            datamapItem._DatamapItems.Add("XYZ", "123");    //Here I added extra key/value pair to your outer object
            Datamap datamap = new Datamap();
            datamap.datamapItems = new List<DatamapItem>();
            datamap.datamapItems.Add(datamapItem);
            string json = JsonConvert.SerializeObject(datamap);   //Here you can serialize your custom key/value pair 
            JObject parsed = JObject.Parse(json);
            Console.WriteLine(parsed);
            Console.ReadLine();
        }
    }
    public class DatamapKey
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> _DatamapKeys;
    }
    public class DatamapItem
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> _DatamapItems;
    }
    public class Datamap
    {
        public List<DatamapItem> datamapItems { get; set; }
    }
    
