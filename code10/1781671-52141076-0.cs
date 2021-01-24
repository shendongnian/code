    // key is question index, value is a list of posssible answers for that question
    var dictionary = new Dictionary<int, List<string>>();
    // list of possible answers for question 0
    var possibleAnswersToQuestionZero = new List<string>(); 
    possibleAnswersToQuestionZero.Add("Possible Answer to question 0");
    possibleAnswersToQuestionZero.Add("Another possible answer to question 0" );
    // add that list to the  dictionary at index 0.
    // you should probably add checks for checking if the key exists before trying to access it's value, 
    // what happens if the list for that key is null or empty, etc.
    dictionary.Add(0, possibleAnswersToQuestionZero);
