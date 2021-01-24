    string simple = returnSimpleObject(complex);
            public class SerializeData
            {
                 public string[] EventData { get; set; }
            }
            private static string returnSimpleObject(string Json)
            {
                JObject jobject = JObject.Parse(Json);
    
                JToken tEventData = jobject.SelectToken("EventData");
                SerializeData myEvent = tEventData.ToObject<SerializeData>();
    
                JToken tchanges = jobject.SelectToken("EventData.ChangeSet.Change.changes");
                myEvent.EventData = tchanges.ToObject<string[]>();
    
                
                JsonSerializer serializer = new JsonSerializer();
                StringWriter strWrite = new StringWriter();
                JsonWriter myWriter = new JsonTextWriter(strWrite);
                serializer.Serialize(myWriter, myEvent);
                return strWrite.ToString();
    
            }
