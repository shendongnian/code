    public static List<System.Web.Mvc.SelectListItem> GenerateSelectList<T>(this IEnumerable<T> itemsToBeAppended)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (T itemToBeAppended in itemsToBeAppended)
            {
                SelectListItem item = new SelectListItem();
                var type = itemToBeAppended.GetType();
                item.Value = type.GetProperty("ID").GetValue(itemToBeAppended).ToString();
                item.Text = type.GetProperty("Name").GetValue(itemToBeAppended).ToString();
                items.Add(item);
            }
            return items.OrderBy(x => x.Text).ToList();
        }
