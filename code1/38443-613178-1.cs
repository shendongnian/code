     protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
                this.ViewData.Model = GLB_MODEL;
                Stream filter = null;
                ViewPage viewPage = new ViewPage();
                viewPage.ViewContext = new ViewContext(filterContext.Controller.ControllerContext, new WebFormView("~/Views/Customer/EmailView.aspx", ""), this.ViewData, this.TempData);
                var response = viewPage.ViewContext.HttpContext.Response;
                response.Clear();
                var oldFilter = response.Filter;
                try
                {
                    filter = new MemoryStream();
                    response.Filter = filter;
                    viewPage.ViewContext.View.Render(viewPage.ViewContext, viewPage.ViewContext.HttpContext.Response.Output);
                    response.Flush();
                    filter.Position = 0;
                    var reader = new StreamReader(filter, response.ContentEncoding);
                    string html = reader.ReadToEnd();
                }
                finally
                {
                    if (filter != null)
                    {
                        filter.Dispose();
                    }
                    response.Filter = oldFilter;
                }
        }
