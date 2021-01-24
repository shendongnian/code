    private IEnumerable<Tuple<string, DateTime, DateTime>> GetUpdatedItems()
    {
        var lst = new List<Tuple<string, DateTime, DateTime>>();
        var items = rpt.Items
            .OfType<RepeaterItem>()
            .Where(x => x.ItemType == ListItemType.Item
                        || x.ItemType == ListItemType.AlternatingItem);
        foreach (var item in items)
        {
            var month = ((Label)item.FindControl("lbl")).Text;
            var dateFromStr = ((TextBox)item.FindControl("txtDateFrom")).Text;
            var dateToStr = ((TextBox)item.FindControl("txtDateTo")).Text;
            var dateFrom = DateTime.Parse(dateFromStr);
            var dateTo = DateTime.Parse(dateToStr);
            lst.Add(Tuple.Create(month, dateFrom, dateTo));
        }
        return lst.ToArray();
    }
