        /// <summary>
        /// For the global MasterPage's footer
        /// </summary>
        /// <returns></returns>
        public static string FooterEditLink(this HtmlHelper helper,
            System.Security.Principal.IIdentity user, string loginText, string logoutText)
        {
            if (user.IsAuthenticated)
                return System.Web.Mvc.Html.LinkExtensions.ActionLink(helper, logoutText, "Logout", "Account",
                    new { returnurl = helper.ViewContext.HttpContext.Request.Url.AbsolutePath }, null);
            else
                return System.Web.Mvc.Html.LinkExtensions.ActionLink(helper, loginText, "Login", "Account",
                    new { returnurl = helper.ViewContext.HttpContext.Request.Url.AbsolutePath }, null);
        }
