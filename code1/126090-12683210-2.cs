    namespace MyApp.Web.Mvc
    {
	    public class PropertyBinderAttribute : Attribute
	    {
	        public PropertyBinderAttribute(Type binderType)
	        {
	            BinderType = binderType;
	        }
	        public Type BinderType { get; private set; }
	    }
    }
