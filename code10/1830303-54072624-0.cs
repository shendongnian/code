    public class GenericClass<T>
    {
        T myProperty { get; set; }
        public GenericClass(T myProperty)
        {
            this.myProperty = myProperty;
        }
    }
