    public class Customer
    
    {
        public int RATE { get; set; }
        public int FEE { get; set; }
        public int PERIOD { get; set; }
    
        public string NewValue
        {
            get
            {
                switch (RATE)
                {
                    case 20:
                        return TestCase.case20;
                    case 40:
                        return TestCase.case40;
                    default:
                        return "";
                }
            }
        }
    }
