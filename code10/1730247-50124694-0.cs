    public static class ListExtensions
    {
        public static List<SelectListItem> ToSelectList<T>(this List<T> list, string idPropertyName, string namePropertyName = "Name")
            where T : class, new()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            list.ForEach(item =>
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.GetType().GetProperty(idPropertyName).GetValue(item).ToString(),
                    Value = item.GetType().GetProperty(namePropertyName).GetValue(item).ToString()
                });
            });
            return selectListItems;
        }
    }
