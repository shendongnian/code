    //Some imports...
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    public static bool PartialViewExists<TModel>(this IHtmlHelper<TModel> html, string viewName)
    {
        var controller = html.ViewContext.ActionDescriptor.RouteValues["controller"];
        var viewEngine = (ICompositeViewEngine)html.ViewContext.HttpContext.RequestServices
            .GetService(typeof(ICompositeViewEngine));
        
        var result = viewEngine.GetView(html.ViewContext.ExecutingFilePath, viewName, false);
        return result.View != null;
    }
