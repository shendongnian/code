      public class BusinessObject
        {
            public BusinessObject(object instantiator)
            {
                if (instantiator.GetType() != typeof(Factory))
                    throw new ArgumentException("Instantiator class must be Factory");
            }
        }
        public class Factory
        {
            public BusinessObject CreateBusinessObject()
            {
                return new BusinessObject(this);
            }
        }
