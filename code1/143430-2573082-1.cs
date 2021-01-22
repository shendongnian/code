    public interface IHasValue
    {
        int Value { get; }
    }
    public class MyClass : IHasValue
    {
        private string value;
        public int Value
        {
            [ExceptionBehavior(typeof(FormatException),
                ExceptionAction.ReturnDefault)]
            get { return int.Parse(this.value); }
        }
    }
