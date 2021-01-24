    public class Sample<T> where T : Parent, new()
    {
        T ChildObject { set; get; }
        public Sample()
        {
            ChildObject = new T(); 
        }
    }
