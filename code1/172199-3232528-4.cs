    public interface IAnswer
    {
       Question Question { get; }
       void Respond(IAnswerFormatter formatter);
    }
