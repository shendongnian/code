    public class Questionnaire
    {
      Collection<Question> _allQuestions;
    
      public Collection<Question> AllQuestions
      {
        get {
          if (_allQuestions == null)
            LoadAllQuestions();
          return _allQuestions;
        }
      }
    
      private void LoadAllQuestions()
      {
        _allQuestions = new Collection<Question>();
        // Some database stuff and fill _allQuestions
      }
    }
