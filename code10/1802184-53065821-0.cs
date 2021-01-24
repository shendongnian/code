    public class IsAuthorizedAttribute : CodeAccessSecurityAttribute
    {
        // set true in the test initialization
        private static bool s_byPass;
    
        public IsAuthorizedAttribute(SecurityAction action) : base(action)
        {
            if (!s_byPass)
            {
               // setup
            }
        }
  
        private static bool IsAuthorised(string entityObject, string field, char expected, ServicesConfiguration servicesConfiguration)
        {
            if (s_byPass) { return true; }
            //check external stuff
        }
    }
