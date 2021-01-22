    public class ModuleViewEngine: WebFormViewEngine
{
	public ModuleViewEngine()
	{
		ViewLocationFormats = new[]
					{
						"~/views/{2}/{1}/{0}.aspx",
						"~/views/{2}/{1}/{0}.ascx",
						"~/views/Shared/{1}/{0}.aspx",
						"~/views/Shared/{1}/{0}.ascx",
					};
		MasterLocationFormats = new[]
		{
				"~/views/{1}/{0}.master",
				"~/views/Shared/{0}.master",
				"~/views/{2}/{1}/{0}.master",
				"~/views/{2}/Shared/{0}.master",
		};
	}
	
	public override ViewEngineResult FindPartialView(ControllerContext controllerContext,
	string partialViewName, bool useCache)
	{
		//coede
	}
	public override ViewEngineResult FindView(
		ControllerContext controllerContext,
	string viewName, string masterName, bool useCache)
	{
		//code
	}
