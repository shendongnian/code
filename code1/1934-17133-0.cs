	public override IEnumerator<T> GetEnumerator()
	{
		// goes through the collection and only returns the ones that are visible for the current user
		// this is done at this level instead of the display level so that ideas do not bleed through
		// on services
		foreach (T idea in InternalCollection)
			if (idea.IsViewingAuthorized)
				yield return idea;
	}
