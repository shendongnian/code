    var Specific = JsonConvert.DeserializeObject(context.Request.Params["SpecificFlt"]);
And ending up with a type of System.Object for "Specific", It might help to deserialize to a custom type as follows:
    public class SpecificObj
    {
        public string DAY {get; set;}
        public string DEP {get; set;}
        public string CARRIER {get; set;}
        public string FLT {get; set;}
        public string LEGCD {get; set;}
    }
