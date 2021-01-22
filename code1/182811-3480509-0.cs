	public static explicit operator Contact(Party p)
	{
		return new Contact
		{
			Type = p.Type,
			Name = p.Name,
			Status = p.Status
		};
	}
