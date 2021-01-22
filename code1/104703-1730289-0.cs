    public static class ControllerHelper
    {
        /// <summary>Renders a view to string.</summary>
        public static string RenderViewToString(this Controller controller,
                                                string viewName, object viewData)
        {
            //Getting current response
            var response = HttpContext.Current.Response;
            //Flushing
            response.Flush();
            
            //Finding rendered view
            var view = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName).View;
            //Creating view context
            var viewContext = new ViewContext(controller.ControllerContext, view,
                                              controller.ViewData, controller.TempData);
            //Since RenderView goes straight to HttpContext.Current, we have to filter and cut out our view
            var oldFilter = response.Filter;
            Stream filter = new MemoryStream(); ;
            try
            {
                response.Filter = filter;
                viewContext.View.Render(viewContext, null);
                response.Flush();
                filter.Position = 0;
                var reader = new StreamReader(filter, response.ContentEncoding);
                return reader.ReadToEnd();
            }
            finally
            {
                filter.Dispose();
                response.Filter = oldFilter;
            } 
        }
        /// <summary>Renders a view to string.</summary>
        public static string RenderSparkToString(this Controller controller,
                                                string viewName, object viewData)
        {
            var view = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName).View;
            //Creating view context
            var viewContext = new ViewContext(controller.ControllerContext, view,
                                              controller.ViewData, controller.TempData);
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            viewContext.View.Render(viewContext, writer);
            writer.Flush();
            return sb.ToString();
        }
    }
