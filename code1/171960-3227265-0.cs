    var order = new Dictionary<string, int>();
    order.Add("S", 0);
    order.Add("P", 1);
    order.Add("NB", 2);
    order.Add("V", 3);
    order.Add("Nc", 4);
    repeater.DataSource = query.OrderBy(p => order[p.Title]);
