    var items = GetItems();
    var sum = TimeSpan.Zero;
    for (int index = items.Count - 1; index > 0; index--)
    {
        var item = items[index];
        var nextItem = items[index - 1];
        if (item.LineName == nextItem.LineName && item.Mode == nextItem.Mode)
        {
            sum += item.Time;
            items.RemoveAt(index);
        }
        else
        {
            item.Time += sum;
            sum = TimeSpan.Zero;
        }
    }
