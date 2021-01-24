    public class ParentObject
    {
        public int ID { get; set; }
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public List<ChildObject> Children { get; set; }
    }
    
    public class ChildObject
    {
        public int ID { get; set; }
        public string PropA { get; set; }
        public string PropB { get; set; }
    }
    
    // Original object before modifications
    var originalObject = new ParentObject
    {
        ID = 1,
        Prop1 = "Prop 1 Original",
        Prop2 = "Prop 2 Original",    
        Children = new List<ChildObject>() { new ChildObject {
                    ID = 22,
                    PropA = "Prop A Original"}
                }
    };
    
    // Get the modified properties
    string modifiedProperties =
        @"[{
            ""ID"": 1,
            ""Prop1"": ""Prop 1 Changed"",
            ""Children"": [{
                ""ID"": 22,
                ""PropA"": ""Prop A Changed""
            }]
        }]";
    
    
    
    /* AUTOMAPPER CODE */
    
    // Convert the JSon into a dynamic list for AUTOMAPPER
    var mapperSources = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpandoObject>>(modifiedProperties);
    
    // Initialize mapper
    AutoMapper.Mapper.Initialize(cfg => { });
    
    // Iterate the list of changes for AUTOMAPPER
    foreach (dynamic source in mapperSources)
    {
        // Get the source ID to pull the record from the database
        var sourceID = Convert.ToInt32(source.ID);
    
        // Simulate a DB call to get the original object
        var destination = originalObject;
    
        // Map the objects together
        var realDestination = AutoMapper.Mapper.Map(source, destination);
    }
    
    
    /* JSON.NET CODE */
    
    // Convert the JSon into a dynamic list for JSON.NET
    Newtonsoft.Json.Linq.JArray sources = Newtonsoft.Json.Linq.JArray.Parse(modifiedProperties);
    
    // Iterate the list of changes for JSON.NET
    foreach (Newtonsoft.Json.Linq.JObject source in sources)
    {
        // Get the source ID to pull the record from the database
        var sourceID = Convert.ToInt32(source["ID"]);
    
        // Simulate a DB call to get the original object
        var destination = originalObject;
    
        // convert the object into a JObject for merge
        Newtonsoft.Json.Linq.JObject tempDestination = Newtonsoft.Json.Linq.JObject.FromObject(destination);
    
        // Map the objects together
        tempDestination.Merge(source, new Newtonsoft.Json.Linq.JsonMergeSettings
        {
            // Using merge
            MergeArrayHandling = Newtonsoft.Json.Linq.MergeArrayHandling.Merge
        });
    
        var realDestination = tempDestination.ToObject<ParentObject>();
    }
    
    /* EXPECTED OUTPUT
        realDestination.ID = 1
        realDestination.Prop1 = "Prop 1 Changed"
        realDestination.Prop2 = "Prop 2 Original"
        realDestination.Children.FirstOrDefault().ID = 22
        realDestination.Children.FirstOrDefault().PropA = "Prop A Changed"
        realDestination.Children.FirstOrDefault().PropB = null
    */
