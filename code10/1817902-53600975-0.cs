    public class Foo<T>
    {
        public string GetPhone(IInterface<T> bar)
        {
            // how would I know what method to call on foo here?
            return bar.????_Phone;
        }
    }
