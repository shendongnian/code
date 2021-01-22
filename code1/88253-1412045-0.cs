    var files = new Dictionary<DateTime, IList<string>>();
    foreach (var file in Directory.GetFiles(...)) {
       var fi = new FileInfo(file);
       var date = fi.CreatedDate();
       var groupDate = new DateTime(date.Year, date.Month);
    
       if (!files.ContainsKey(groupDate)) files.Add(groupDate, new Collection<string>());
    
       files[groupDate].Add(file);
    }
