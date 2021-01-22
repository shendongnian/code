    [NonAction]
        public List<SelectListItem> ToSelectList(IEnumerable<A> as, string defaultOption)
        {
            var items = as.Select(a => new SelectListItem() { Text = a.Description, Value = a.Id.ToString() }).ToList();
            items.Insert(0, new SelectListItem() { Text = defaultOption, Value = "-1" });
            return items;
        }
