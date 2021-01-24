    var files = Directory
     .EnumerateFiles(@"c:\MyFiles", "*_????????_??????.*")  // raw filtering
     .Where(file => {                                         // fine filtering
       string name = Path.GetFileNameWithoutExtension(file);
       string at = name.Substring(name.IndexOf('_') + 1);
       return DateTime.TryParseExact(                         // is it a proper date?
         at,
         "yyyyMMdd'_'HHmmss",
         CultureInfo.InvariantCulture,
         DateTimeStyles.AssumeLocal,
         out var _date); })
     .ToArray();       // Finally, we want an array
