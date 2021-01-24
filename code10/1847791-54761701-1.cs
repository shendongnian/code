    private IEnumerable<Tuple<string, string>> GetSelectedItems()
    {
        var lst = new List<Tuple<string, string>>();
        var items = rpt.Items
            .OfType<RepeaterItem>()
            .Where(x => x.ItemType == ListItemType.Item 
                        || x.ItemType == ListItemType.AlternatingItem);
        foreach (var item in items)
        {
            var chk = (CheckBox)item.FindControl("chk");
            if (chk.Checked)
            {
                var hidden = (HiddenField)item.FindControl("hidden");
                lst.Add(Tuple.Create(chk.Text, hidden.Value));
            }
        }
        return lst.ToArray();
    }
