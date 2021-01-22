    public interface IInterface {
        event EventHandler QuestionAsked;
    }
    public class Class : IInterface {
        event EventHandler QuestionAsked;
        //As with typical events you might want an protected OnQuestionAsked
    }
