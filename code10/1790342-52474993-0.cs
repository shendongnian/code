    string fullWord = "Hello****wide****world";
    string delimiter = "****";
    
    var listOfWords = fullWord.Split(delimiter);
    StringBuilder result = new StringBuilder("");
    result.Append("{");
    foreach(var item in listOfWords){
      if (!item.Equals(listOfWords.Last()))
      {
           result.Append($"\"{item}\",\"{delimiter}\",");
      }
      else
      {
           result.Append($"\"{item}\"");
      }
    }
    result.Append("}");
    var stringResult=result.ToString();
