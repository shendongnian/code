    public static class ExtensionMethods
    {
        public static string RenderPartialToString(this ControllerBase controller, string partialName, object model)
        {
            var vd = new ViewDataDictionary(controller.ViewData);
            var vp = new ViewPage
            {
                ViewData = vd,
                ViewContext = new ViewContext(),
                Url = new UrlHelper(controller.ControllerContext.RequestContext)
            };
            ViewEngineResult result = ViewEngines
                                      .Engines
                                      .FindPartialView(controller.ControllerContext, partialName);
            if (result.View == null)
            {
                throw new InvalidOperationException(
                string.Format("The partial view '{0}' could not be found", partialName));
            }
            var partialPath = ((WebFormView)result.View).ViewPath;
            vp.ViewData.Model = model;
            Control control = vp.LoadControl(partialPath);
            vp.Controls.Add(control);
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                using (var tw = new HtmlTextWriter(sw))
                {
                    vp.RenderControl(tw);
                }
            }
            return sb.ToString();
        }
    }
