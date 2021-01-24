    var files = Directory
     .EnumerateFiles(@"c:\MyFiles", "*_????????_??????.*")  // raw filtering
     .Where(file => {                                         // fine filtering
       string name = Path.GetFileNameWithoutExtension(file);
       // from second last underscope '_' 
       string at = name.Substring(name.LastIndexOf('_', name.LastIndexOf('_') - 1) + 1);
       return DateTime.TryParseExact(                         // is it a proper date?
         at,
         "yyyyMMdd'_'HHmmss",
         CultureInfo.InvariantCulture,
         DateTimeStyles.AssumeLocal,
         out var _date); })
     .ToArray();       // Finally, we want an array
