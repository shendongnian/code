    public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, long selectedId) 
         where T : ISelectable
    {
        return
            items.OrderBy(item => item.Name)
            .Select(item =>
                    new SelectListItem
                    {
                        Selected = (item.Id == selectedId),
                        Text = item.Name,
                        Value = item.Id.ToString()
                    });
    }
