	[DataObjectMethod(DataObjectMethodType.Select)]
	public IEnumerable<OperatorField> FindByType(String type)
	{
		foreach (OperatorField ce in this.OperatorFields)
		{
			if (ce.Type == type)
				yield return ce;
		}
	}
