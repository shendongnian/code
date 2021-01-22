    public class AuthenticationSoapExtensionAttribute : SoapExtensionAttribute
    {
        private int priority;
    
        public AuthenticationSoapExtensionAttribute()
        {
        }
    
        public override Type ExtensionType
        {
            get
            {
                return typeof(AuthenticationSoapExtension);
            }
        }
    
        public override int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
    }
