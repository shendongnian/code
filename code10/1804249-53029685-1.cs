    class JsonModel {
        public string property1 { get; set; }
        public int property2 { get; set; }
        public string property3 { get; set; }
    }
    var json_string = "{ \"property1\" : \"value\", \"property2\" : 2, \"property3\" : { \"subprperty1\" : \"value\" } }";
    var jObj = JObject.Parse(json_string);
    var obj = new JsonModel()
    {
        property1 = jObj["property1"].ToString(),
        property2 = (int) jObj["property2"],
        property3 = jObj["property3"].ToString(),
    };
    Console.WriteLine(dict["property3"].ToString());
