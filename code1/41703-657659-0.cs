    public interface ISomething { void Action(); }
    public class Something : ISomething
    {
        public void Action()
        {
        }
        void ISomething.Action()
        {
        }
    }
    public class Something2 : ISomething
    {
        void ISomething.Action()
        {
        }
    }
