    string json = @"{
      'd': [
        {
          'Name': 'John Smith'
        },
        {
          'Name': 'Mike Smith'
        }
      ]
    }";
    
    JObject o = JObject.Parse(json);
    
    JArray a = (JArray)o["d"];
    
    IList<Person> person = a.ToObject<IList<Person>>();
    
    Console.WriteLine(person[0].Name);
    // John Smith
    
    Console.WriteLine(person[1].Name);
    // Mike Smith
