            public static SelectList SetSelectedValue(SelectList list, string value)
        {
            if (value != null)
            {
                var selected = list.Where(x => x.Value == value).First();
                selected.Selected = true;
                return list;
            }
            return list;
        }
