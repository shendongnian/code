    string htmlMessage = RenderViewToString("NewsBrodcast", newsBrodcastModel);
        public static string RenderViewToString(string viewPath, object model, bool partial = false, ViewDataDictionary viewDataDictionary = null)
        {
            try
            {
                if (!viewPath.Contains("~/Views/Email"))
                {
                    viewPath = "~/Views/Email/" + viewPath + ".cshtml";
                }
                // first find the ViewEngine for this view
                ViewEngineResult viewEngineResult = null;
                if (partial)
                    viewEngineResult = ViewEngines.Engines.FindPartialView(FakeControllerContext, viewPath);
                else
                    viewEngineResult = ViewEngines.Engines.FindView(FakeControllerContext, viewPath, null);
                if (viewEngineResult == null)
                    throw new FileNotFoundException("View cannot be found.");
                if (viewDataDictionary == null)
                    viewDataDictionary = new ViewDataDictionary();
                // get the view and attach the model to view data
                var view = viewEngineResult.View;
                viewDataDictionary.Model = model;
                using (var sw = new StringWriter())
                {
                    var ctx = new ViewContext(FakeControllerContext, view, viewDataDictionary, FakeControllerContext.Controller.TempData, sw);
                    view.Render(ctx, sw);
                    return sw.ToString();
                }
            }
            catch (Exception)
            {               
                throw;
            }
        }
       
        public static HttpContext FakeHttpContext()
        {
            var httpRequest = new HttpRequest("", "https://example.com/", "");
            var stringWriter = new StringWriter();
            var httpResponse = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponse);
            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                new HttpStaticObjectsCollection(), 10, true,
                HttpCookieMode.AutoDetect,
                SessionStateMode.InProc, false);
            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null, CallingConventions.Standard,
                    new[] { typeof(HttpSessionStateContainer) },
                    null)
                .Invoke(new object[] { sessionContainer });
            return httpContext;
        }
        private static HttpContext Ctx => HttpContext.Current ?? FakeHttpContext();
        private static ControllerContext _fakeControllerContext;
        private static ControllerContext FakeControllerContext
        {
            get
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Fake");
                _fakeControllerContext = new ControllerContext(new HttpContextWrapper(Ctx), routeData, new FakeController());
                return _fakeControllerContext;
            }
        }
        private class FakeController : ControllerBase { protected override void ExecuteCore() { } }
