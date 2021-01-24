	public override bool Equals(object obj)
	{
		if (obj is Participant participant)
		{
			return participant.Name == Name;
		}
		
		return false;
	}
