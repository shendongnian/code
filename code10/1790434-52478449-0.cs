        public class YourModel
          {
        
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
          }
    
        class YourClass
          {
            public IEnumerable<YourModel> YourModels{ get; set; }
          }
    
     string jsonString = //your json will go here
    
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    YourClass data= serializer.Deserialize<YourClass >(jsonString);
            }
