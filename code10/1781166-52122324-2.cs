    var dateRE = new Regex(@"\[(\d\d-\d\d-\d\d)\] \[(\d\d-\d\d)\](?=.xlsx)", RegexOptions.Compiled);
    if (fileNameArray.Length > 0) {
        var ans = fileNameArray.Select((n, i) => {
                                    var dtMatch = dateRE.Match(n);
                                    return new { Filename = n, Index = i, Filedate = DateTime.ParseExact(dtMatch.Groups[1].Value+" "+dtMatch.Groups[2].Value, "MM-dd-yy HH-mm", CultureInfo.InvariantCulture) };
                                })
                               .OrderByDescending(nid => nid.Filedate)
                               .First();
    }
