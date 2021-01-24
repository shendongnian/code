    SystemInformation information = new SystemInformation();
    foreach(var item in values)
	{
		information.GetType()
                        .GetProperty(item.Key)
                        .SetValue(information, item.Value);
    }
