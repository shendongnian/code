    Page pageHolder = new Page();
    UserControl viewControl = (UserControl)pageHolder.LoadControl(@"MyComponent.ascx");
    pageHolder.Controls.Add(viewControl);
    StringWriter output = new StringWriter();
    HttpContext.Current.Server.Execute(pageHolder, output, false);
    return output.ToString();
