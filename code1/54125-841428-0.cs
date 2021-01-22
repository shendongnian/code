    public static string RenderUserControl(string path)
    {
        Page pageHolder = new Page();
        Control viewControl = pageHolder.LoadControl(path);
        pageHolder.Controls.Add(viewControl);
        using(StringWriter output = new StringWriter())
        {
            HttpContext.Current.Server.Execute(pageHolder, output, false);
            return output.ToString();
        }
    }
