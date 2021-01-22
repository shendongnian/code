    public class Test : ITest
    {
        public string Property
        {
            get;
        }
        object ITest.Property
        {
            get
            {
                return Property;
            }
        }
    }
