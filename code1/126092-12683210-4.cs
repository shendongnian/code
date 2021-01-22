    namespace MyApp.Web.Models
    {
	    public class MyModel
	    {
	        [PropertyBinder(typeof(TimeSpanBinder))]
	        public TimeSpan InspectionDate { get; set; }
	    }
    }
