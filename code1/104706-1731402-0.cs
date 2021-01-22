    public static string RenderSparkToString(this Controller controller,
                                            string viewName, string masterName, object viewData)
    {
        var view = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, masterName).View;
        //Creating view context
        var viewContext = new ViewContext(controller.ControllerContext, view,
                                          controller.ViewData, controller.TempData);
        var sb = new StringBuilder();
        var writer = new StringWriter(sb);
        viewContext.View.Render(viewContext, writer);
        writer.Flush();
        return sb.ToString();
    }
  
