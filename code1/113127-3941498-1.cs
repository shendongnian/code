    updateRelativeTimeString = new Timer(s =>
        Items.ForEach(
             item => item.RelativeTime = item.Date.ToRelativeTime()),
        null,
        0,
        5000);
