    [AttributeUsage(AttributeTargets.Assembly)]
    public class CustomResourceAttribute : Attribute
    {        
        private string the_variable;
    	public string Variable	{get { return the_variable; }}
        private string the_value;
    	public string Value     {get { return the_value; }}
        public CustomResourceAttribute(string variable, string value)
        {
            this.the_variable = variable;
            this.the_value = value;
        }
    }
