    public static class ControllerExtensions
    {
		public static string PartialViewToHtml(this Controller controller, string viewName)
		{
			return controller.PartialViewToHtml(viewName, null);
		}
        public static string PartialViewToHtml(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
			if (model != null)
				controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var result = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var context = new ViewContext(controller.ControllerContext, result.View, controller.ViewData, controller.TempData, writer);
                result.View.Render(context, writer);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
