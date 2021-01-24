    public class A
    {
        public new configObject config
        {
            get
            {
                var baseConfig = base.config;
                //Modify baseConfig properties here
                return baseConfig;
            }
            set { base.config = value; }
        }
    }
