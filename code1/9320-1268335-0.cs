	public bool IsController(string controller)
	{
		if (ViewContext.RouteData.Values["controller"] != null)
		{
			return ViewContext.RouteData.Values["controller"].ToString().Equals(controller, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}
	public bool IsAction(string action)
	{
		if (ViewContext.RouteData.Values["action"] != null)
		{
			return ViewContext.RouteData.Values["action"].ToString().Equals(action, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}
	public bool IsAction(string action, string controller)
	{
		return IsController(controller) && IsAction(action);
	}
