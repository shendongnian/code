    Page page = new Page();
    page.EnableEventValidation = false;
    
    HtmlForm form = new HtmlForm();
    form.Name = "form1";
    page.Controls.Add(form1);
    
    MyControl mc = new MyControl();
    form.Controls.Add(mc);
    
    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    HtmlTextWriter writer = new HtmlTextWriter(sw);
    
    page.RenderControl(writer);
    
    return sb.ToString();
