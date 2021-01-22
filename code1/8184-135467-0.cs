    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
    public class RestMethodAttribute: Attribute
    {
        private HttpVerb _verb;
    
        public RestMethodAttribute(HttpVerb verb)
        {
            _verb = verb;
        }
    
        public HttpVerb Verb
        {
            get { return _verb; }
        }
    }
