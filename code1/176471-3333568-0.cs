	public class Template
	{
		public string Name { get; set; }
		public string Content { get; set; }
		public string this[string name]
		{
			get
			{
				return typeof(Template).GetProperty(name).GetValue(this, null).ToString();
			}
			set
			{
				typeof(Template).GetProperty(name).SetValue(this, value, null);
			}
		}
	}
