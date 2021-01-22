    System.Web.UI.Page page = new System.Web.UI.Page();
    UserControl ctrl = (UserControl)page.LoadControl("~/Controls/CalendarMonthView.ascx");
    page.Form.Controls.Add(ctrl);
    ctrl.DoSomething();
    context.Response.CacheControl = "No-Cache";
    context.Server.Execute(page, context.Response.Output, true);
