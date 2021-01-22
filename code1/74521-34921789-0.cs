    //Sentence has quotes
    string nameSentence = "Take my name \"Wesley\" out of quotes";
    //Get the index before the quotes`enter code here`
    int begin = nameSentence.LastIndexOf("name") + "name".Length;
    //Get the index after the quotes
    int end = nameSentence.LastIndexOf("out");
    //Get the part of the string with its quotes
    string name = nameSentence.Substring(begin, end - begin);
    //Remove its quotes
    string newName = name.Replace("\"", "");
    //Replace new name (without quotes) within original sentence
    string updatedNameSentence = nameSentence.Replace(name, newName);
    //Returns "Take my name Wesley out of quotes"
    return updatedNameSentence;
