    <% List<TreeViewItem> checkedNodes = ViewData["TreeView1_checkedNodes"] as ist<TreeViewItem>; %>
    <%= Html.Telerik().TreeView()
    .Name("Tree")    
    .ShowCheckBox(true)
    .ClientEvents(ev => ev.OnChecked("OnCheck")
    )
    .BindTo(Model, mappings =>
    {
        mappings.For<GridWithWindow.Jar>(binding => binding
            .ItemDataBound((item, jag) =>
                {
                    item.Text = jag.TreeName;
                    item.Value = jag.TreeName;
                    if (checkedNodes != null)
                    {
                        var checkedNode = checkedNodes
                                            .Where(e => e.Value.Equals("ddd"))
                                            .FirstOrDefault();
                        item.Checked = checkedNode != null ? checkedNode.Checked : false;
                    }                    
                })
                .Children(jag => jag.FirstLevelIList));
        mappings.For<GridWithWindow.Jaguar.FirstLevel>(binding => binding
            .ItemDataBound((item, frst) =>
                {
                    item.Text = frst.FirstLevelName;
                    item.Value = frst.FirstLevelName;
                })
