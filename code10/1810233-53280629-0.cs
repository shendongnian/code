    string date = "12 NOV 2018 16:08:52:000:000:000";
    if(date.Count(c => c == ':') >= 2) // skip check if it's always valid
    {
       date = date.Remove(date.Remove(date.LastIndexOf(':')).LastIndexOf(':'));
       DateTime result = System.DateTime.ParseExact(date, "dd MMM yyyy HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
    }
