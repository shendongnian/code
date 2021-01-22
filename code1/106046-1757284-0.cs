    using(var sw = new System.IO.StringWriter()) // SW is a buffer into which the control is rendered
    using(var writer = new HtmlTextWriter(sw))
    {
        myControl.RenderControl(writer);
        return sw.ToString(); // This returns the generated HTML.
    }
