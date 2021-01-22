    public sealed class WebServiceSettings
    {
        private static readonly WebServiceSettings instance=new WebServiceSettings();
        private static int webServiceId;
        static WebServiceSettings()
        {
             webServiceId = //set webServiceId
        }
        
        private WebServiceSettings(){}
        public static WebServiceSettings Current
        {
            get
            {
                return instance;
            }
        }
        public int WebServiceId {get{return webServiceId;}}
    }
