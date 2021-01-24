	protected object TryInject(Type concreteType, IEnumerable<object> dependencies)
	{
		var constructors = concreteType
			.GetConstructors
			(
			    BindingFlags.Public | BindingFlags.Instance
		    )
			.OrderByDescending
			(
			    c => c.GetParameters().Length
		    );
		foreach (var c in constructors)
		{
			var parameters = c.GetParameters();
			var arguments = parameters
				.Select
				(
				    p => dependencies.FirstOrDefault
				    (
					    d => p.ParameterType.IsAssignableFrom(d.GetType())
				    )
			    )
			    .ToArray();
			if (!arguments.Contains( null ))
			{
				return Activator.CreateInstance(concreteType, arguments);
			}
		}
		return null;
	}
