    private string FindCommonPrefix(List<string> list)
    {
        List<string> prefixes = null;
        for (int len = 1; ; ++len)
        {
            var x = list.Where(s => s.Length >= len)
                        .GroupBy(c => c.Substring(0,len))
                        .Where(grp => grp.Count() > 1)
                        .Select(grp => grp.Key)
                        .ToList();
            if (!x.Any())
            {
                break;
            }
            //  Copy last list
            prefixes = new List<string>(x);
        }
        return prefixes == null ? string.Empty : prefixes.First();
    }
