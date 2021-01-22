        public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue)
        {
            return from Enum e in Enum.GetValues(enumValue.GetType())
                   select new SelectListItem
                              {
                                  Selected = e.Equals(enumValue),
                                  Text = e.ToString(),
                                  Value = e.ToString()
                              };
        }
