    var groupedItems = from item in items
                       group item by new
                       {
                           item.ItemID,
                           IntervalKey = (long)new TimeSpan(item.Date.Ticks).TotalMinutes / 5
                       } 
                       into g
                       select g;
