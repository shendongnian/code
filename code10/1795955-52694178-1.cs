    settings.Columns.Add(column =>     
    {
            column.FieldName = "Unbound";
            column.Caption = "Action";
            column.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            column.EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.True;
            column.ReadOnly = false;
            column.ColumnType = MVCxGridViewColumnType.ButtonEdit;
            column.SetDataItemTemplateContent((c) =>
            {
                Html.DevExpress().Button(b =>
                {
                    b.Name = "btnVE" + c.KeyValue;
                    b.Text = "V/E";
                    b.UseSubmitBehavior = false; // prevent default submit action
                    b.EnableClientSideAPI = true; // add this line if not sure
                    b.ClientSideEvents.Click = string.Format("function(s, e) {{ window.location = '{0}'; }}",
                            DevExpressHelper.GetUrl(new { Controller = "ViewPrincipal", Action = "EditRecord", id = c.KeyValue.ToString() }));
                }).GetHtml();
            });
        });
