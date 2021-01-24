    public class AType<T>: IEnumerable<T>
    {
        public AType() // parameterless constructor if you need it
        {
        }
        public AType(IEnumerable<T> source)
        {
            // use data from source to initialize AType
        }
        // implementation of IEnumerable<T> interface goes here
    }
