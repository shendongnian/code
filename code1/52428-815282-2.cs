    //Class For Storing Question Information
    public class QuestionAnswers {
       public string Question { get; private set; }
       public List<string> Answers { get; private set; }
       public QuestionAnswers(string question, IEnumerable<string> answers) {
          Question = question;
          Answers = new List<string>(answers);
       }
    }
    //Dictionary declaration
    static Dictionary<string, QuestionAnswers> sourceList = new Dictionary<string, QuestionAnswers>();
    
    //Foreach loop which populates a Dictionary with results from
    //a linq query that i need to print out.
    foreach (var v in linqQueryResult) {
       QuestionAnswers qa = new QuestionAnswers(v.question, v.solution.Select(s => s.Answer));
       sourceList.Add(qa.Question, qa);
    }          
    //foreach loop to print out contents of Dictionary
    foreach (QustionAnswers qa in sourceList.Values) {
       Debug.WriteLine(qa.Question);
       foreach(string answer in qa.Answers) {
          Debug.WriteLine(answer);
       }
    }
