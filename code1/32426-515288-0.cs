    public class BusinessObject
    {
        private BusinessObject(string property)
        {
        }
        public class Factory
        {
            public static BusinessObject CreateBusinessObject(string property)
            {
                return new BusinessObject(property);
            }
        }
    }
