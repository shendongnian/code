    foreach (var p in sh)  {
        _ShowCollection.Add(new ShowsQu {
            Date = p.Date,
            Time = p.Time,
            Description = p.Description
        });
    }
