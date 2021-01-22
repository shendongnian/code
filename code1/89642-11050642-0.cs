    public static SelectList ToSelectList(this DataTable table, string valueField, string textField)
		{
			List<SelectListItem> list = new List<SelectListItem>();
			foreach (DataRow row in table.Rows)
			{
				list.Add(new SelectListItem() { Text = row[textField].ToString(), Value = row[valueField].ToString() });
			}
			return new SelectList(list, "Value", "Text");
		}
