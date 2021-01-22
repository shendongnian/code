            return from item in items
                   select new SelectListItem
                   {
                       Text =item.GetPropValue("Name"),
                        Value = item.GetPropValue("Id"),
                         Selected = item.GetPropValue("Id").Equals(selectedVal.ToString())
                   };
        }
        public static string GetPropValue<T> (this T item,string refName)
        {
            return item.GetType().GetProperty(refName).GetValue(item).ToString();
        }
