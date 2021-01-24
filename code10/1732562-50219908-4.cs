	public string GiveThisAName
	{
		get
		{
			if (String.IsNullOrWhiteSpace(ime))
			{
				return null;
			}
			
			if (String.IsNullOrWhiteSpace(priimek))
			{
				return null;
			}
			
			return ime[0] + '.' + priimek[0];
		}
	}
