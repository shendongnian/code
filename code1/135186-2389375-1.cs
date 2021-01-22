    public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, 
        int selectedId, Func<T,int> getId, Func<T, string> getName, 
        Func<T, string> getText, Func<T, string> getValue)
    {
        return
            items.OrderBy(item => getName(item))
            .Select(item =>
                    new SelectListItem
                    {
                        Selected = (getId(item) == selectedId),
                        Text = getText(item),
                        Value = getValue(item)
                    });
    }
