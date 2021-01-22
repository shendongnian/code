    var obj = JsonConvert.DeserializeObject<Response>(sResponse);
    Debug.Assert(obj2.Name == "Bodø");
    Debug.Assert(obj2.HomePage == "http://www.ex.com");
    public class Response
    {
        public string Name { get; set; }
        public string HomePage { get; set; }
    }
