    public class DateTimeAnswer : IAnswer
    {
        public DateTimeAnswer(Question question, DateTime value)
        {
            Question = question;
        }
        public Question Question { get; protected set; }
    
        protected DateTime Response {get; set;}
    
        public virtual void Respond(IAnswerFormatter formatter)
        {
            formatter.Write(Response);
        }
    }
