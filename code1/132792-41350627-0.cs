    // convert to a string/string dictionary and remove anynulls that may have been passed in as a string "null"
    var formDictionary = form.AllKeys
                         .Where(p => form[p] != "null")
                         .ToDictionary(p => p, p => form[p]);
    string json = JsonConvert.SerializeObject(formDictionary);
    var myObject = JsonConvert.DeserializeObject<MyClass>(json);
 
