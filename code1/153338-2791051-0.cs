        public static string Render<T>(string controlPath, Action<T> initControlCallback) where T : Control
        {
            Page renderPage = new Page();
            // Load the control & add to page
            T control = (T) renderPage.LoadControl(controlPath);
            renderPage.Controls.Add(control);
            // Initialize the control
            initControlCallback.Invoke(control);
            renderPage.DataBind();
            StringWriter result = new StringWriter();
            HttpContext.Current.Server.Execute(renderPage, result, false); // Render Process
            return result.ToString();
        }
