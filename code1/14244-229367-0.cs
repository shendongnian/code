        /// <summary>
        /// Renders a LoggingWeb user control.
        /// </summary>
        /// <param name="helper">Helper to extend.</param>
        /// <param name="control">Type of control.</param>
        /// <param name="data">ViewData to pass in.</param>
        public static void RenderLoggingControl(this System.Web.Mvc.HtmlHelper helper, LoggingControls control, object data)
        {
            string controlName = string.Format("{0}.ascx", control);
            string controlPath = string.Format("~/Controls/{0}", controlName);
            string absControlPath = VirtualPathUtility.ToAbsolute(controlPath);
            if (data == null)
            {
                helper.RenderPartial(absControlPath, helper.ViewContext.ViewData);
            }
            else
            {
                helper.RenderPartial(absControlPath, data, helper.ViewContext.ViewData);
            }
        }
