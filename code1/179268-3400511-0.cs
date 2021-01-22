        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            var locale = requestContext.RouteData.Values["locale"].ToString() ?? System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            base.Initialize(requestContext);
        }
