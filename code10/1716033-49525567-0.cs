    public class B
    {
        public configObject config
        {
            get
            {
                var config = new configObject
                {
                    property1 = value1
                    property2 = value2;
                    property3 = null
                    property4 = false;
                };
        
                return config;
            }
        
            set { this.config = value; }  //This is actually a StackOverflow error!
        }
    }
