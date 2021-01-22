    = (UpdatePanel)chart.Parent.FindControl(chart.ID + "UP");
}
    GridView gv = new GridView();
    Dictionary<string, string> displayFields =
        new Dictionary<string, string>();
    // add data to displayFields by using the ImageMapEventArgs.PostBackValue
    // to create data for dictionary ...
    gv.DataSource = displayFields;
    gv.DataBind();
    up.ContentTemplateContainer.Controls.Add(gv);
