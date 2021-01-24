    namespace Kendo.Mvc.UI.Fluent
    {
        public class WindowBuilder : WidgetBuilderBase<Window, WindowBuilder>, IHideObjectMembers
    	{
            // other methods
    
            public WindowBuilder Content(Func<object, object> value)
    		{
    			base.Component.Template.InlineTemplate = value; // this is the inline template
    			return this;
    		}
    
            // other methods
        }
    }
