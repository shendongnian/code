	public AbstractType New
	{
		get
		{
			return (AbstractType) Activator.CreateInstance(GetType());
		}
	}
