    public static Home CreateFromJObject(JObject obj)
	{
		Home h = new Home();
		foreach (var a in obj)
		{
			if (a.Key == "ID")
			{
				h.Id = a.Value.Value<int>();
			}
			else
			{
				h.propertyName = a.Key;
				h.Text = a.Value.Value<string>();
			}
		}
		return h;
	}
