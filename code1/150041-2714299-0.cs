      [AttributeUsage(AttributeTargets.Method, 
                      AllowMultiple = false, Inherited = true)]
      public class SubmitCommandAttribute : ActionMethodSelectorAttribute
      {
        private string _submitName;
        private string _submitValue;
        private static readonly AcceptVerbsAttribute _innerAttribute = 
                                     new AcceptVerbsAttribute(HttpVerbs.Post);
        
        public SubmitCommandAttribute(string name) : this(name, string.Empty) { }
            public SubmitCommandAttribute(string name, string value)
        {
              _submitName = name;
              _submitValue = value;
        }
    
        public override bool IsValidForRequest(ControllerContext controllerContext, 
                                               MethodInfo methodInfo)
        {
          if (!_innerAttribute.IsValidForRequest(controllerContext, methodInfo))
            return false;
    
          // Form Value
          var submitted = controllerContext.RequestContext
                                           .HttpContext
                                           .Request.Form[_submitName];
          return string.IsNullOrEmpty(_submitValue)
                   ? !string.IsNullOrEmpty(submitted)
                   : string.Equals(submitted, _submitValue, 
                                   StringComparison.InvariantCultureIgnoreCase);
        }
      }
