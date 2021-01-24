    public class Model
    {
        [FromForm(Name = "response[key]")]
        public string key { get; set; }
        [FromForm(Name = "response[name]")]
        public string name { get; set; }
    }
