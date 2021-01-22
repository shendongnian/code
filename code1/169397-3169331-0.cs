    static public string GetHTML(Control myControl)
    {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter myWriter = new HtmlTextWriter(sw);
            myControl.RenderControl(myWriter);
            return sw.ToString();
    }
