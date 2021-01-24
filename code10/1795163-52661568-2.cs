    Html.DevExpress().Button(b =>
    {
        b.Name = "btnVE" + c.KeyValue;
        b.Text = "V/E";
        b.ClientSideEvents.Click =
        "function(s, e) { document.location='" + DevExpressHelper.GetUrl(new { Controller = "ViewPrincipal", Action = "EditRecord" })
        + "?key=' + s.GetRowKey(e.visibleIndex); }"; // ==> 's' refers to button object as sender
    }).GetHtml();
