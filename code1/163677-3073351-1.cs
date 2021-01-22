		public static string DropDownList(this HtmlHelper helper, string name, Type type, object selected)
		{
			if (!type.IsEnum)
				throw new ArgumentException("Type is not an enum.");
			if (selected != null && selected.GetType() != type)
				throw new ArgumentException("Selected object is not " + type.ToString());
			var enums = new List<SelectListItem>();
			foreach (int value in Enum.GetValues(type))
			{
				var item = new SelectListItem();
				item.Value = value.ToString();
				item.Text = Enum.GetName(type, value);
				if (selected != null)
					item.Selected = (int)selected == value;
				enums.Add(item);
			}
			// set ViewData first
			helper.ViewData[name] = enums;
			// pass in "null" intentionally into the DropDownList extension method
			return System.Web.Mvc.Html.SelectExtensions.DropDownList(helper, name, null, "--Select--");
		}
