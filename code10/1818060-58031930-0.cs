	using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	public static void Add<TFilterType>(this ICollection<IFilterMetadata> filters) where TFilterType : IFilterMetadata {
		var typeFilterAttribute = new TypeFilterAttribute(typeof(TFilterType));
		filters.Add(typeFilterAttribute);
	}
