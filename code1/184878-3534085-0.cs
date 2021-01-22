        public IColumn GetColumnByPropertyName(string PropertyName)
        {
			var c = Columns.SingleOrDefault(x => x.Name.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase));
			if (c == null)
			{
				c=Columns.SingleOrDefault(x => CleanUpColumnName(x.Name).Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase));
				if (c == null)
				{
					throw new NotSupportedException("Couldn't find column name");
				}
			}
			return c;
        }
		private string CleanUpColumnName(string name)
		{
			//don't forget to change Settings.ttinclude:CleanUp when changing this function! 
			string result = name;
			if (result.EndsWith("_id", StringComparison.OrdinalIgnoreCase))
			{
				result = result.Substring(0, result.Length - 3);
				result += "RID";
			}
			return result;
		}
