    var csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
                string[] csvlines = File.ReadAllLines(txt_filePath.Text.ToString());
    
                var query = csvlines.Select(csvline => new
                {
                    data = csvSplit.Matches(csvline)
                }).Select(t => t.data);
    
                var row = query.Select(matchCollection =>
                    (from Match m in matchCollection select (m.Value.Contains(',')) ? m.Value.Replace(",", "") : m.Value)
                    .ToList()).ToList();
