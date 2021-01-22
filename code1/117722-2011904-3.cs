    var rotated = new List<List<string>> {
        new List<string>(), new List<string>(), new List<string>(),
    };
    for each (MyDataClass object in myCollection) 
    {
        rotated[0].Add(object.Category);
        rotated[1].Add(object.Content);
        rotated[2].Add(object.OtherField.ToString("n0"));
    }
