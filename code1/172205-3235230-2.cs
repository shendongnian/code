    public class Questionnaire
    {
     public AnswerCollection Answers { get; set; }
    }
    
    public class AnswerCollection : Collection<Answer>
    {
      // Subclassed Collection<T> for Add/Remove Semantics etc.
    }
    
    public abstract class Answer : IAnswer<object>
    {
      public override object Response { get { // Base Impl. Here }; }
    
      public abstract string CommonOperation()
     {
       // This is the key, the "common operation" - likely ToString?
       // (for rendering the answer to the screen)
       // Hollywood Principle - let the answers figure out how they
       // are to be displayed...
     }
    }
    
    public class DateTimeAnswer : Answer, IAnswer<DateTime>
    {
     public override DateTime Response { get { // Do Stuff }; }
     public override string CommonOperation() { return "I can haz DateTime"; }
    }
