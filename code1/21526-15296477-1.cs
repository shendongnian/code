	public class MvcApplication : System.Web.HttpApplication
	{
    ...
		protected void Application_Start(object sender, EventArgs e)
		{
			ModelBinders.Binders.DefaultBinder = new MyDefaultModelBinder();
        }
    }
