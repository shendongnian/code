    // key is question index, value is a list of possible answers for that question
    var dictionary = new Dictionary<int, List<string>>();
    // list of possible answers for question 0 (random question number chosen for the example)
    var possibleAnswersToQuestionZero = new List<string>(); 
    possibleAnswersToQuestionZero.Add("Possible Answer to question 0");
    possibleAnswersToQuestionZero.Add("Another possible answer to question 0");
    // add that list to the dictionary at key 0.
    // you should be also checking if the key exists before trying to access it's value, 
    // and what happens if the list returned for that key is null or empty.
    dictionary.Add(0, possibleAnswersToQuestionZero);
