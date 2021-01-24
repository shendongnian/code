    class JsonModel 
    {
       string property1 {get; set;}
       int property2 {get; set;}
       SomeOtherMagicalClass property3 {get; set;}
    }
    
    class SomeOtherMagicalClass 
    {
       string subprperty1 {get; set;}
    }
    ...
    var results = JsonConvert.DeserializeObject<JsonModel>(json_string);
