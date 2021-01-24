    // convert it to C# concrete classes
    var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
    // convert to dictionary 
    var dictionary = rootObject.List.ToDictionary(x => x.code, x => x.value);
    // create new object with dictionary
    var newObject = new NewObject() {List = dictionary};
    // output
	var output = JsonConvert.SerializeObject(newObject, Formatting.Indented);
