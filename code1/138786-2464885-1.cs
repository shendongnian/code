    // Renders the partial view with an empty view data and the given model
    public static void RenderPartial(this HtmlHelper htmlHelper, string partialViewName, object model) {
        htmlHelper.RenderPartialInternal(partialViewName, htmlHelper.ViewData, model, htmlHelper.ViewContext.Writer, ViewEngines.Engines);
    }
    internal virtual void RenderPartialInternal(string partialViewName, ViewDataDictionary viewData, object model, TextWriter writer, ViewEngineCollection viewEngineCollection) {
        if (String.IsNullOrEmpty(partialViewName)) {
            throw new ArgumentException(MvcResources.Common_NullOrEmpty, "partialViewName");
        }
        ViewDataDictionary newViewData = null;
        if (model == null) {
            if (viewData == null) {
                newViewData = new ViewDataDictionary(ViewData);
            }
            else {
                newViewData = new ViewDataDictionary(viewData);
            }
        }
        else {
            if (viewData == null) {
                newViewData = new ViewDataDictionary(model);
            }
            else {
                newViewData = new ViewDataDictionary(viewData) { Model = model };
            }
        }
        ViewContext newViewContext = new ViewContext(ViewContext, ViewContext.View, newViewData, ViewContext.TempData, writer);
        IView view = FindPartialView(newViewContext, partialViewName, viewEngineCollection);
        view.Render(newViewContext, writer);
    }
