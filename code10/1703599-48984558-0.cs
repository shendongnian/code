     class Program
            {       
                    static void Main(string[] args)
                    {            
                        JObject parsed = JObject.Parse(File.ReadAllText("test.json"));
                       var response = JsonConvert.DeserializeObject<Example>(parsed.ToString());
                        var dict =(JObject) parsed["Data"];                
                        Dictionary<string,List<MonthInfo>> dictValues = new Dictionary<string,List<MonthInfo>>();
                        foreach(var itme in dict)
                        {
                            dictValues.Add(itme.Key,JsonConvert.DeserializeObject<List<MonthInfo>>(itme.Value.ToString()));
                        }
                 
                    response.Data = dictValues;
                    Console.WriteLine(JsonConvert.SerializeObject(response));
                    Console.ReadLine();
                    }         
                
            }
        
           
            public class MonthInfo
            {
                public string title { get; set; }
                public string titlePopup { get; set; }
                public string color { get; set; }
                public int msgId { get; set; }
                public DateTime start { get; set; }
                public DateTime end { get; set; }
                public int allDay { get; set; }
                public string attachment { get; set; }
                public string genFile { get; set; }
                public int is_Holiday { get; set; }
            }
        
          
        
            public class Example
            {
                public string ResponseStatus { get; set; }
                public string ResponseCode { get; set; }
                public string ResponseMessage { get; set; }
                public Dictionary<string, List<MonthInfo>> Data { get; set; }
                
            }
