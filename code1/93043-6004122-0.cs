    public static string RenderUserControl(string path, List<KeyValuePair<string, object>> properties)
        {
            Page pageHolder = new Page();
            UserControl viewControl = (UserControl)pageHolder.LoadControl(path);
            viewControl.EnableViewState = false;
            Type viewControlType = viewControl.GetType();
            foreach (var pair in properties)
            {
                PropertyInfo property = viewControlType.GetProperty(pair.Key);
                if (property != null)
                {
                    property.SetValue(viewControl, pair.Value, null);
                }
            }
            HtmlForm f = new HtmlForm();
            f.Controls.Add(viewControl);
            pageHolder.Controls.Add(f);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, false);
            return (output.ToString());
        }
