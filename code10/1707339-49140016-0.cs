    var convertJSONToObj= JsonConvert.DeserializeObject<Data>(json);
    public class Persons
    {
         public string index { get; set; }
         public string thing { get; set; }
         public string name { get; set; }
         public string title { get; set; }
    }
    
    public class Data
    {
         public List<Person> data {get; set;}
    }
