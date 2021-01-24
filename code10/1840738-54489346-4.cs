    private IEnumerable<Question> _questions;
    _questions = new List<Question>()
    {
        new Question("Question 1","How do i work with tuples"),
        new Question("Question 2","How to use Queryable.Where when type is set at runtime?")
    };
    var filters = new NameValueCollection 
    { 
       { "Description", "work" }
    };
    var results = _questions.Filter(filters);
