    public class GenericTestClass<T> where T : BaseClass
    {
        public BaseClass Entity => EntityCast;
        public T EntityCast { get; }
        public GenericTestClass(T myClass)
        {
            EntityCast = myClass;
        }
    }
