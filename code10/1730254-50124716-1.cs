    public static class EnumerableExtension
    {
        public static SelectList ToSelectList(this IEnumerable<ICustomLookup> items)
        {
            return new SelectList(items.Select(thisItem => new SelectListItem
            {
                Text = thisItem.X,
                Value = thisItem.Y
            }));
        }
    }
