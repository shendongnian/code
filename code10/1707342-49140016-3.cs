    Stream newStream = response .GetResponseStream();
    StreamReader sr = new StreamReader(newStream);    
    var result = sr.ReadToEnd();    
    //this will turn your response into a c# object of RootObject Type
    //only do this is you're sure it will Deserialize into a RootObject type. 
    var convertResponseToObj= JsonConvert.DeserializeObject<RootObject>(result); 
    //if you want to see what's being returned by your endpoint 
    //without turning it into a RootObject type then remove <RootObject> see line below.
    //doing this may help you Deserialize the response correctly. 
    
    //var convertResponseToObj= JsonConvert.DeserializeObject(result); 
    public class Persons
    {
         public string index { get; set; }
         public string thing { get; set; }
         public string name { get; set; }
         public string title { get; set; }
    }
    
    public class RootObject
    {
         public List<Person> data {get; set;}
    }
