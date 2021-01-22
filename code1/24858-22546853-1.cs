        enum Abc
        {
            [Description("Cba")]
            Abc,
    
            Def
        }
        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var value in values)
            {
                string text = value.ToString();
                var member = typeof(TEnum).GetMember(value.ToString());
                if (member.Count() > 0)
                {
                    var customAttributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (customAttributes.Count() > 0)
                    {
                        text = ((DescriptionAttribute)customAttributes[0]).Description;
                    }
                }
                items.Add(new SelectListItem
                {
                    Text = text,
                    Value = value.ToString(),
                    Selected = (value.Equals(selectedValue))
                });
            }
            return htmlHelper.DropDownList(
                name,
                items
                );
        }
