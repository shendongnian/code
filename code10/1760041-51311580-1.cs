    public static List<SelectListItem> ToSelectList(this List<Tuple<int, string>> list)
    {
        return list
            .Select(x => new SelectListItem
            {
                Value = x.Item1.ToString(),
                Text = x.Item2
            })
            .ToList();
    }
