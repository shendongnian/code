    string yourinputshidden = "<input type=\"hidden\" id=\"taken\" value=\"BoboBobo\">\n<input type=\"hidden\" id=\"took\" value=\"BaboboBe\"";
    string[] splitted = yourinputshidden.split(new[] { "\n<input" }, StringSplitOptions.None);
    Dictionary<string, string> inputs = new Dictionary<string, string>(); // the list of inputs, by ID, Value
    foreach(string item in splitted )
    {
        string splittedAgain = item.split(new[] { "=\"" }, StringSplitOptions.None);
        string inputId = splittedAgain[3].replace("\"", "");
        string inputValue = splittedAgain[5].replace("\"", "");
        inputs.Add(inputId, inputValue);
    }
    // Continue your code
