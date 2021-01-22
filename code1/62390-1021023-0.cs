    Page page = new Page();
    
    /*Not the exact way I init the control. But that's irrevelant*/
    Control control = new Control();
    page.Controls.Add(control)
    string controlHtml;
    
    using(StringWriter sw = new StringWriter())
    {
       HttpContext.Current.Server.Execute(page, sw, false);
       controlHtml = sw.ToString();
    }
