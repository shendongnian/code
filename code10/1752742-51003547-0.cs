    var Content = "nickname:Steven ID:01 nickname:pascal ID:02 nickname:nils ID:03";
    var list = Regex.Matches(Content, @"nickname:(.+?)\s+ID:(\d+)")
                .Cast<Match>()
                .Select(m => new
                {
                    Name = m.Groups[1].Value,
                    ID = m.Groups[2].Value
                })
                .ToList();
