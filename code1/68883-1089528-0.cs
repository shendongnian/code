    string json = JsonConvert.SerializeObject(people, Formatting.Indented,
      new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
    //[
    //  {
    //    "$id": "1",
    //    "Name": "James",
    //    "BirthDate": "\/Date(346377600000)\/",
    //    "LastModified": "\/Date(1235134761000)\/"
    //  },
    //  {
    //    "$ref": "1"
    //  }
    //]
    
    List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(json,
      new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
    
    Console.WriteLine(deserializedPeople.Count);
    // 2
    
    Person p1 = deserializedPeople[0];
    Person p2 = deserializedPeople[1];
    
    Console.WriteLine(p1.Name);
    // James
    
    Console.WriteLine(p2.Name);
    // James
    
    bool equal = Object.ReferenceEquals(p1, p2);
    // true
