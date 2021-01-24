    public static IOrderedEnumerable<string> GetFiles(string batchFilePath)
            {
                if (Directory.Exists(batchFilePath))
                {
                    var directoryInfo = new DirectoryInfo(batchFilePath);
                    var fileEntries = directoryInfo.GetFiles(@"Batch *.xlsx").Select(x => x.Name).OrderBy(f => GetFileDay(f));
                    return fileEntries;
                }
    
                return null;
            }
        private static DateTime GetFileDay(string file)
        {
            var date = default(DateTime);
            var extractedDate = Regex.Match(file, @"(\W\S*(\d[\d]{0,2}))").Value;
            extractedDate = extractedDate.Replace(".", "-").Trim();           
            DateTime.TryParseExact(extractedDate, "d-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date);
            return date;
        }
