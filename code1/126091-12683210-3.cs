    namespace MyApp.Web.Mvc.PropertyBinders
    {
	    public class TimeSpanBinder : IPropertyBinder
	    {
	        readonly HttpContextBase _httpContext;
	        public TimeSpanBinder(HttpContextBase httpContext)
	        {
	            _httpContext = httpContext;
	        }
	        public object BindModel(
	            ControllerContext controllerContext,
	            ModelBindingContext bindingContext,
	            MemberDescriptor memberDescriptor)
	        {
	            var timeString = _httpContext.Request.Form[memberDescriptor.Name].ToLower();
	            var timeParts = timeString.Replace("am", "").Replace("pm", "").Trim().Split(':');
	            return
	                new TimeSpan(
	                    int.Parse(timeParts[0]) + (timeString.Contains("pm") ? 12 : 0),
	                    int.Parse(timeParts[1]),
	                    0);
	        }
	    }
    }
