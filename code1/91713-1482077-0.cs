    public abstract class TestProperty<T>
    {
        public abstract T PropertyValue { get; set; }
    }
    
    public class StringProperty : TestProperty<string>
    {
    }
