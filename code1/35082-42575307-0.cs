    [AttributeUsage(..., AllowMultiple = true)]
    public class MyCustomAttribute : Attribute
    {
        public override object TypeId
        {
            get
            {
                return this;
            }
        }
    }
