    public IDictionary<int, bool> CheckAnswers(Dictionary<int, string> exam, Dictionary<int, string> answers)
    {
         var results = new Dictionary<int, bool>();
         for(var index = 0; index < exam.Length; index++)
         {
             if(String.Compare(exam[index], answers[index], true) == 0)
                 results.Add(exam[index], true);
             
              results.Add(exam[index], false);
         }
    
         return results;
    }
    var correct = CheckAnswers(..., ...).Where(answer => answer.Value == true).Count();
