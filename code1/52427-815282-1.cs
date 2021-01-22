    //Dictionary declaration
    static Dictionary<string, List<string>> sourceList = new Dictionary<string, List<string>>();
    
    //Foreach loop which populates a Dictionary with results from
    //a linq query that i need to print out.
    foreach (var v in linqQueryResult) {
       List<string> answers = v.solution.Select(s => s.Answer).ToList();
       sourceList.Add(v.question, answers);
    }          
    //foreach loop to print out contents of Dictionary
    foreach (KeyValuePair<string, List<string>> item in sourceList) {
       Debug.WriteLine(item.Key);
       foreach(string answer in item.Value) {
          Debug.WriteLine(answer);
       }
    }
