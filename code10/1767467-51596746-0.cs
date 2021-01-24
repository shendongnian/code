    List<string> list = new List<string>();
    
    list.Add("Arts and Craft");
    list.Add("APPLE - Nutrients");
    list.Add("Science and Technology");
    list.Add("Culture");
    list.Add("APPLE - Interests");
    list.Add("APPLE - Awesome");
    list.Add("Bowling");
    list.Add("APPLE - Healthy");
    
    var sortedList = list.Where(x => x.Substring(0, 5) != "APPLE").OrderBy(y => y)
                       .Concat(list.Where(x => x.Substring(0, 5) == "APPLE").OrderBy(y => y));
