	/// <summary>
	/// Returns a filtered list of persons
	/// </summary>
	/// <param name="search">Filters. Only filters that are set (not null or empty) are applied</param>
	/// <param name="persons">List to filter</param>
	/// <returns>Filtered list or a new list of all persons if no filters provided</returns>
	/// <exception cref="ArgumentNullException"> Thrown if 'search' or 'persons' is null </exception>
	static List<Person> Filter(SearchParam search, IEnumerable<Person> persons)
	{
        if( search == null ) throw new ArgumentNullException(nameof(search));
        if (persons == null) throw new ArgumentNullException(nameof(persons));
		IEnumerable<Person> filtered = persons;
		if( !string.IsNullOrEmpty(search.FirstName))
		{
			filtered = filtered.Where( p => string.Compare( p.FirstName, search.FirstName, StringComparison.CurrentCultureIgnoreCase ) == 0);
		}
		if (!string.IsNullOrEmpty(search.LastName))
		{
			filtered = filtered.Where(p => string.Compare(p.LastName, search.LastName, StringComparison.CurrentCultureIgnoreCase) == 0);
		}
		if (search.DOB.HasValue)
		{
			//This filter should probably allow searching only by year, etc.
			filtered = filtered.Where(p =>p.DOB == search.DOB);
		}
		return filtered.ToList();
	}
