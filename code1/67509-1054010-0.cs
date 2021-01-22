    public class CustomParameter : Parameter
    {
        protected override object Evaluate(HttpContext context, Control control)
        {
            // This is where you would grab and return
            // the Page.User.ProviderUserKey value
            return string.Empty;
        }
    }
