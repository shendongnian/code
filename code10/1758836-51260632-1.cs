	public Guid? DoSomethingWithList(List<ofthings> myList)
	{
		foreach (var member in myList)
		{
			try
			{
			  //Do fancy and dangerous stuff in here.
			}
			catch (Exception ex)
			{
				 throw new ListProcessingException(member, ex);
			}
		}
	}
