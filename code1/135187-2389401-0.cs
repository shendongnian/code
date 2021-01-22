    public static IEnumerable<SelectListItem> ToSelectListItems(
         this IEnumerable<T> items, 
         Func<T,string> nameSelector, 
         Func<T,string> valueSelector, 
         Func<T,bool> selected)
    {
         return items.OrderBy(item => nameSelector(item))
                .Select(item =>
                        new SelectListItem
                        {
                            Selected = selected(item),
                            Text = nameSelector(item),
                            Value = valueSelector(item)
                        });
    }
