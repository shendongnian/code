    String asciiText = "104, 101, 108, 108, 111, 44, 32, 119, 111, 114, 108, 100"
    var splited = asciiText.Split(',');
    String finalString = String.Empty;
    
    foreach(var item in splited)
    {
       int unicode = Int32.Parse(item.Trim());
       char character = (char) unicode;
       string text = character.ToString();
       finalString += text;
    }
