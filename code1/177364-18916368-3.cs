		public static MvcHtmlString SimpleDropDown(this HtmlHelper helper, object attributes, IEnumerable<SelectListItem> items, bool disabled = false)
		{
			XElement e = new XElement("select",
				items.Select(a => {
					XElement option = new XElement("option", a.Text);
					option.SetAttributeValue("value", a.Value);
					if (a.Selected)
						option.SetAttributeValue("selected", "selected");
					return option;
				})
				);
			if (attributes != null)
			{
				Dictionary<string, string> values = (from x in attributes.GetType().GetProperties() select x).ToDictionary(x => x.Name, x => (x.GetGetMethod().Invoke(attributes, null) == null ? "" : x.GetGetMethod().Invoke(attributes, null).ToString()));
				foreach(var v in values)
					e.SetAttributeValue(v.Key, v.Value);
			}
			if (disabled)
				e.SetAttributeValue("disabled", "");
			return new MvcHtmlString(e.ToString());
		}
