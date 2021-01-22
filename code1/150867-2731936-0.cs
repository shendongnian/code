    public interface IBindable<T>
    {
        // Property declaration:
        T Text
        {
            get;
            set;
        }
    }
    public class MyTextBox : IBindable<string>
    {
        public string Text
        {
            get;
            set;
        }
    }
