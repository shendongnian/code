    Stream newStream = response .GetResponseStream();
    StreamReader sr = new StreamReader(newStream);    
    var result = sr.ReadToEnd();    
    //this will turn your response into a c# object of Data Type
    var convertResponseToObj= JsonConvert.DeserializeObject<Data>(result); 
    //if you want to see what's being returned by your endpoint 
    //without turning it into a Data type then remove <Data> see line below.
    
    //var convertResponseToObj= JsonConvert.DeserializeObject(result); 
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
