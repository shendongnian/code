    Dictionary<DateTime, decimal> avg = new Dictionary<DateTime, decimal>();
    foreach (MyObject obj in items)
    {
        if (avg.ContainsKey(obj.Created.Date))
        {
            avg[obj.Created.Date] += (decimal)obj.Value;
        }
        else
        {
            avg.Add(obj.Created.Date, (decimal)obj.Value);
        }
    }
    foreach (var item in avg.ToList())
    {
        avg[item.Key] =Math.Round(item.Value / items.Count(x => x.Created.Date == Convert.ToDateTime(item.Key).Date),1);
    }
