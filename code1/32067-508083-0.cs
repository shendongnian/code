    public class BusinessTest
    {
        private BusinessSubTest aSub;
        public BusinessTest()
        {
            aSub = new BusinessSubTest(this);
        }
    }
    public class BusinessSubTest
    {
        public BusinessSubTest(BusinessTest aTest)
        {
            
        }    
    }
