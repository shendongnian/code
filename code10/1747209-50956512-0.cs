    private Dictionary<string, object> CreateParametersDictionary(List<FilterRange> filters, int skip = 0, int take = 0)
    {
        var dict = new Dictionary<string, object>()
        {
            { "@skip", skip },
            { "@take", take },
        };
        for (var i = 0; i < filters.Count; i++)
        {
            dict.Add($"column_{i}", filters[i].Filter.Description);
                
            // some logic here which determines how you parse
            // I used a switch, not shown here for brevity
            dict.Add($"@fromVal_{i}", int.Parse(filters[i].FromValue.Value));
            dict.Add($"@toVal_{i}", int.Parse(filters[i].ToValue.Value));                         
        }
        return dict;
    }
