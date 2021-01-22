    public interface ISomething { void Action(); }
    public interface ISomethingElse {void Action(); }
    public class Something : ISomething
    {
        public void Action()
        {
        }
        void ISomething.Action()
        {
        }
    }
    public class Something2 : ISomething, ISomethingElse
    {
        void ISomething.Action()
        {
        }
        void ISomethingElse.Action()
        {
        }
    }
