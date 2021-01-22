    class WebInstanceService 
    {
        private HttpContextBase _Context;        
        public WebInstanceService( ... , HttpContextBase HttpContext )
        {
            ....
            _Context = HttpContext;
        }
        // Methods...
        public string GetInstanceVariable(string VariableName)
        {
             return _Context.Session[VariableName];
        }
    }
