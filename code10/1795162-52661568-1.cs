    column.SetDataItemTemplateContent((c) =>
    {
        Html.DevExpress().Button(b =>
        {
            b.Name = "btnVE" + c.KeyValue;
            b.Text = "V/E";
            b.UseSubmitBehavior = false; // prevent default submit action
            b.EnableClientSideAPI = true; // add this line if not sure
            b.ClientSideEvents.Click =
            "function(s, e) { window.location = '" + DevExpressHelper.GetUrl(new { Controller = "ViewPrincipal", Action = "EditRecord" })
            + "?key=" + c.KeyValue + "'; }";
        }).GetHtml();
    });
