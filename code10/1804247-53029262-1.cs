    class JsonModel<T> 
    {
       string property1 {get; set;}
       int property2 {get; set;}
       T property3 {get; set;}
    }
    
    class SomeOtherMagicalClass 
    {
       string subprperty1 {get; set;}
    }
    ...
    var results = JsonConvert.DeserializeObject<JsonModel<SomeOtherMagicalClass>>(json_string);
