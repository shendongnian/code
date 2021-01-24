    String strValue = "city, image, N'Hello, World , It Rain', picture";
    // Match the sentences by N'{text}'
    var strValues = Regex.Match(strValue, "(?<=N')(.*?)(?=')");
    
    // Remove the sentences from the string
    foreach(var matchedVal in strValues.Captures){
        var toRepl = String.Format("N'{0}', ", matchedVal.ToString());
        strValue = strValue.Replace(toRepl, "");
    }
    
    // Split the remainder of the string
    List<string> strOtherValues = strValue.Split(new string[] { ", " }, StringSplitOptions.None).ToList();
    
    // Add all sentences to words list
    foreach (var matchedVal in strValues.Captures)
    {
        strOtherValues.Add(matchedVal.ToString());
    }
