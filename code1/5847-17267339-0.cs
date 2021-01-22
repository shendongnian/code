		var typesInAssemblies = assembliesToSearch.SelectMany(assembly => assembly.GetTypes());
		return typesInAssemblies.Where(abstractType.IsAssignableFrom);
	}
	/// <summary>
	/// Returns the results of <see cref="GetImplementors"/> that match <see cref="IsInstantiable"/>.
	/// </summary>
	public static IEnumerable<Type> GetInstantiableImplementors(this Type abstractType, params Assembly[] assembliesToSearch)
	{
		var implementors = abstractType.GetImplementors();
		return implementors.Where(IsInstantiable);
	}
	/// <summary>
	/// Determines whether <paramref name="type"/> is a concrete, non-open-generic type.
	/// </summary>
	public static bool IsInstantiable(this Type type)
	{
		return !(type.IsAbstract || type.IsGenericTypeDefinition || type.IsInterface);
	}
