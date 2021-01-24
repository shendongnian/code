    //your object, with [DataContract] and [DataMember] attributes
    var yourObject = new YourObject();
    //populate the properties or whatever you want with your object
    yourObject.Blabla = 1;
    //serialize your object into a string
    var objectSerialized = JsonConvert.SerializeObject(yourObject);
    //your Regex string pattern, something like this?
    var pattern = Odata.Filter;
    //Use Regex to try to match the  pattern with the serialized object, no IQueryable needed
    var match = Regex.Match(objectSerialized, pattern);
    //See if the regex matched
    if (match.Success)
        //do something
