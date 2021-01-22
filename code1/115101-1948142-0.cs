    public static void RenderRightHandPane(this HtmlHelper helper, YourViewModelType model)
    {
        switch(model.CurrentPane.ToLower())
        {
            case "sent":
                helper.RenderPartialView("SentPartial", model.SomeData);
            case "inbox":
                helper.RenderPartialView("InboxPartial", model.SomeData);
            case "alerts": 
                helper.RenderPartialView("AlertsPartial", Model.SomeData);
            case default:
                // Add a default handler - perhaps rendering a not found-view...?
        }
    }
