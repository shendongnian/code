            return (from  item in items.OfType<EventEntry>()
                    select new EventDto
                               {
                                   Url = item.FeedUri,
                                   Title = item.Title.Text,
                                   Date =   item.Times[0].StartTime.ToShortDateString()
                    }).Take(cnt);
        }
