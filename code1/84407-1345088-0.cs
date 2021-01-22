    public interface IOurTemplate<T, U>
        where T : class
    {
        IEnumerable<T> List();
        T Get(U id);
    }
    public class TestInterface : IOurTemplate<MyCustomClass, Int32?>
    {
        public IEnumerable<MyCustomClass> List()
        {
            throw new NotImplementedException();
        }
        public MyCustomClass Get(Int32? testID)
        {
            throw new NotImplementedException();
        }
    }
